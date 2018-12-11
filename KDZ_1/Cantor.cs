using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_1
{
    class Cantor : Fractal
    {
        public float sizey = 10, dsizey=10;
        public Cantor() : base(){
            xsize = ysize = 600;
        }
        public Cantor(float dwigth, float wigth=10) : base(){
            this.sizey = wigth;
            this.dsizey = dwigth;
        }

        /// <summary>
        /// Задать dsizey
        /// </summary>
        /// <param name="f">Значение передаваемое dsizey</param>
        public override void set_float(float f)
        {
            this.dsizey = f;
            
        }

        /// <summary>
        /// До какого уровня рекурсии длина элемента множества Кантора будет >= 1
        /// </summary>
        /// <param name="mlor">Максимальный уровень рекурсии</param>
        /// <param name="s">Начальная длина элемента множества Кантора</param>
        /// <returns></returns>
        public int count_len(int mlor, float s)
        {
            int counter = 0;
            while (s / 3 >= 1) {
                s /= 3;
                counter++;
            }
            return Math.Min(counter+2, mlor);
        }

        /// <summary>
        /// Инициализация отрисовки фрактала
        /// </summary>
        /// <param name="graph">Куда отрисовывать</param>
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
                }
            }
            else
            {
                if (mlor > 0)
                {
                    this.colorarrmax = (mlor + 1);
                    this.colorarr = new Colorarr(colorarrmax, startColor, endColor);
                    this.colorarrstep = bindrob(colorarrmax, 2, mlor);
                }
            }
            graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, (xsize + space * 2) * scale, (sizey + dsizey + space * 2) * scale);
            try
            {
                rec(graph, 0 + space * scale, (System.Math.Max(((pictureBoxYsize - (sizey * scale * mlor + dsizey * scale * Math.Max(mlor - 1, 0)) + yspace * scale) / 2) - 0, 0) + space) * scale, xsize * scale, 0);
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
        /// <param name="x">Координата x верхнего левого угла</param>
        /// <param name="y">Координата y верхнего левого угла</param>
        /// <param name="w">Длинна элемента</param>
        /// <param name="lor">Текущий уровень рекурсии</param>
        void rec(System.Drawing.Graphics g, float x, float y, float w, float lor)
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
