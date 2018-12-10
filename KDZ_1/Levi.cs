using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_1
{
    class Levi : Fractal
    {
        //protected Line[] l;
        
        /// <summary>
        /// Инициализация отрисовки фрактала
        /// </summary>
        /// <param name="graph">Куда отрисовывать</param>
        public override void Draw(System.Drawing.Graphics graph)
        {
            graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, (xsize * 8 / 8 + space * 2)*scale, (ysize + space * 2)*scale);
            //message = "" + pictureBoxXsize + "  " + pictureBoxYsize + "  " + (pictureBoxXsize - xsize + xspace) / 2 + "  " + (pictureBoxYsize - ysize + yspace) / 2 + "  " + (xsize + space * 2) + "  " + (ysize + space * 2);
            //return;
            if (max_level_of_rec>0)
            {
                //this.colorarrmax = (binpow(2, max_level_of_rec) < 0 ? int.MaxValue : binpow(2, max_level_of_rec));
                this.colorarrmax = (max_level_of_rec+1);
                this.colorarr = new Colorarr(colorarrmax, startColor, endColor);
                this.colorarrstep = bindrob(colorarrmax, 2, max_level_of_rec);
            }
            try
            {
                rec(graph, (0 + space + xsize * 9 / 16)*scale, (0 + space + ysize * 3 / 4)*scale, (0 + space + xsize * 9 / 16)*scale, (0 + space + ysize / 4)*scale, 0);
            }
            catch (StackOverflowException)
            {
                message = "Слишком большая глубина рекусии (установите количество итераций для построения фрактала на меньшее значение";
            }
        }

        /// <summary>
        /// Рекурсивное вычисление и отрисовка фрактала
        /// </summary>
        /// <param name="g">Куда отрисовывать</param>
        /// <param name="xs">Координата x начальной точки</param>
        /// <param name="ys">Координата y начальной точки</param>
        /// <param name="xe">Координата x конечной точки</param>
        /// <param name="ye">Координата y конечной точки</param>
        /// <param name="lor">Текущий уровень рекурсии</param>
        void rec(System.Drawing.Graphics g, float xs, float ys, float xe, float ye, float lor)
        {
            if (!isdrawing) return;
            this.summ += this.step;
            try
            {
                lock (_vlock) { this.pb.progressBar1.Value = Math.Min(this.pbm - 3, (int)(this.summ)); }
            }
            catch (System.InvalidOperationException ex)
            {

            }

            //this.pb.progressBar1.Value = Math.Min(pb.progressBar1.Maximum - 3, (int)(this.summ));
            level_of_rec = (int)lor;
            if (lor == max_level_of_rec)
            {
                //message = "" + xs + " " + ys + " " + xe + " " + ye;
                return;
            }


            if (Math.Abs((xe - xs)) < 1 && Math.Abs((ye - ys)) < 1 && !drawall && lor != 0)
            {
                return;
            }

            //Start another recursions
            float dx = Math.Abs(xe - xs) / 4, dy = Math.Abs(ye - ys) / 4;
            if (lor % 2 == 0)
            {
                if (Math.Abs(xs-xe)<0.1)
                {
                    if (ys < ye)
                    {
                        rec(g, xs, ys, xs + 2 * dy, ys + 2 * dy, lor + 1);
                        rec(g, xs + 2 * dy, ys + 2 * dy, xe, ye, lor + 1);
                    }
                    else
                    {
                        rec(g, xs, ys, xs - 2 * dy, ys - 2 * dy, lor + 1);
                        rec(g, xs - 2 * dy, ys - 2 * dy, xe, ye, lor + 1);
                    }
                }
                else
                {
                    if (xs < xe)
                    {
                        rec(g, xs, ys, xs + dx * 2, ys - dx * 2, lor + 1);
                        rec(g, xs + 2 * dx, ys - 2 * dx, xe, ye, lor + 1);
                    }
                    else
                    {
                        rec(g, xs, ys, xs - dx * 2, ys + dx * 2, lor + 1);
                        rec(g, xs - 2 * dx, ys + 2 * dx, xe, ye, lor + 1);
                    }
                }
            }
            else
            {
                float xl = Math.Min(xs, xe), xr = Math.Max(xs, xe), yu = Math.Min(ys, ye), yd = Math.Max(ys, ye);
                //if (ye < ys)
                //{
                //    rec(g, xl, yu, xr, yu, lor + 1);
                //    rec(g, xl, yu, xl, yd, lor + 1);
                //}
                //else
                //{
                //    rec(g, xl, yd, xr, yd, lor + 1);
                //    rec(g, xl, yu, xl, yd, lor + 1);
                //}
                //rec(g, xs, ye, xe, ye, lor + 1);
                //rec(g, xs, yu, xs, yd, lor + 1);
                if(xs < xe && ys > ye)
                {
                    rec(g, xs, ys, xs, ye, lor + 1);
                    rec(g, xs, ye, xe, ye, lor + 1);
                }
                if (xs < xe && ys < ye)
                {
                    rec(g, xs, ys, xe, ys, lor + 1);
                    rec(g, xe, ys, xe, ye, lor + 1);
                }
                if (xs > xe && ys < ye)
                {
                    rec(g, xs, ys, xs, ye, lor + 1);
                    rec(g, xs, ye, xe, ye, lor + 1);
                }
                if (xs > xe && ys > ye)
                {
                    rec(g, xs, ys, xe, ys, lor + 1);
                    rec(g, xe, ys, xe, ye, lor + 1);
                }
            }
            
            //Print figure
            if (max_level_of_rec > 0)
            {
                this.pen.Color = this.colorarr.colorarr[(int)(lor)];
                //colorarriter += colorarrstep;
            }
            g.DrawLine(this.pen, xs, ys, xe, ye);


            if (lor == 0)
            {
                this.isdrawing = false;
                Fractal.handle.Set();
            }
        }

    }
}