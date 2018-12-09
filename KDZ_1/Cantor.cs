using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_1
{
    class Cantor : Fractal
    {
        //protected Line[] l;
        public float sizey = 10, dsizey=10;
        public Cantor() : base(){
            xsize = ysize = 600;
        }
        public Cantor(float dwigth, float wigth=10) : base(){
            this.sizey = wigth;
            this.dsizey = dwigth;
        }
        public override void set_float(float f)
        {
            this.dsizey = f;
            
        }
        public int count_len(int mlor, float s)
        {
            int counter = 0;
            while (s / 3 >= 1) {
                s /= 3;
                counter++;
            }
            return Math.Min(counter+2, max_level_of_rec);
        }
        public override void Draw(System.Drawing.Graphics graph)
        {
            int mlor = count_len(max_level_of_rec, size * scale);
            if (this.drawall)
            {
                if (max_level_of_rec > 0)
                {
                    this.colorarrmax = (max_level_of_rec + 1);
                    this.colorarr = new Colorarr(colorarrmax, startColor, endColor);
                    this.colorarrstep = bindrob(colorarrmax, 2, max_level_of_rec);
                    //this.colorarrmax = (mlor < 0 ? int.MaxValue : mlor);
                    //this.colorarr = new Colorarr(colorarrmax);
                    //this.colorarrstep = colorarrmax/mlor;
                }
                //graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, (xsize + space * 2) * scale, (sizey * max_level_of_rec + dsizey * max_level_of_rec + space * 2) * scale);
            }
            else
            {
                if (mlor > 0)
                {
                    this.colorarrmax = (mlor + 1);
                    this.colorarr = new Colorarr(colorarrmax, startColor, endColor);
                    this.colorarrstep = bindrob(colorarrmax, 2, mlor);
                    //this.colorarrmax = (mlor < 0 ? int.MaxValue : mlor);
                    //this.colorarr = new Colorarr(colorarrmax);
                    //this.colorarrstep = colorarrmax/mlor;
                }
                //graph.FillRectangle(System.Drawing.Brushes.White, 0, System.Math.Max(((pictureBoxYsize - (sizey * scale * mlor + dsizey * scale * Math.Max(mlor - 1, 0) + space * scale * 2) + yspace * scale) / 2) - yleft, 0), (xsize + space * 2) * scale, (sizey * mlor + dsizey * Math.Max(mlor - 1, 0) + space * 2) * scale);
            }
            graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, (xsize + space * 2) * scale, (sizey + dsizey + space * 2) * scale);
            //message = "" + pictureBoxXsize + "  " + pictureBoxYsize + "  " + (pictureBoxXsize - xsize + xspace) / 2 + "  " + (pictureBoxYsize - ysize + yspace) / 2 + "  " + (xsize + space * 2) + "  " + (ysize + space * 2);
            //return;
            //message = "" + mlor + "  " + max_level_of_rec;
            //this.colorarr = new Colorarr(mlor);
            try
            {
                rec(graph, 0 + space * scale, (System.Math.Max(((pictureBoxYsize - (sizey * scale * mlor + dsizey * scale * Math.Max(mlor - 1, 0)) + yspace * scale) / 2) - 0, 0) + space) * scale, xsize * scale, 0);
            }
            catch (StackOverflowException)
            {
                message = "Слишком большая глубина рекусии (установите количество итераций для построения фрактала на меньшее значение";
            }
        }

        void rec(System.Drawing.Graphics g, float x, float y, float w, float lor)
        {
            if (!isdrawing) return;
            this.summ += this.step;
            try
            {
                lock (_vlock) { this.pb.progressBar1.Value = Math.Min(pb.progressBar1.Maximum - 3, (int)(this.summ)); }
            }
            catch (System.InvalidOperationException ex)
            {

            }
            //this.pb.progressBar1.Value = Math.Min(pb.progressBar1.Maximum - 3, (int)(this.summ));
            level_of_rec = (int)lor;
            if (lor == max_level_of_rec)
            {
                return;
            }
            
            if (w < 1 && !drawall && lor != 0)
            {
                return;
            }

            g.FillRectangle(System.Drawing.Brushes.White, 0, y, space * scale, (sizey + dsizey * Math.Min(lor, 1) + space) * scale);
            g.FillRectangle(System.Drawing.Brushes.White, x, y, (xsize + space * 2) * scale - x, (sizey + dsizey + space) * scale);
            //Start another recursions
            rec(g, x, y + sizey * scale + dsizey * scale, w / 3, lor+1);
            rec(g, x + 2 * w / 3, y + sizey * scale + dsizey * scale, w / 3, lor+1);

            //Print figure
            if (max_level_of_rec > 0)
            {
                this.brush = new System.Drawing.SolidBrush(this.colorarr.colorarr[(int)(lor)]);
            }
            g.FillRectangle(this.brush, x, y, w, this.sizey * scale);



            if (lor == 0)
            {
                this.isdrawing = false;
                Fractal.handle.Set();
            }
        }
    }

}
