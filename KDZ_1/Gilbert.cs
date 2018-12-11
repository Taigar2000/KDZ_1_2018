using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_1
{
    class Gilbert : Fractal
    {
        public override int Max_length
        {
            get
            {
                return max_length;
            }
            set
            {
                max_length = binpow(4, Math.Min(value, (int)16)-1);
                max_length2 = max_length;
            }
        }

        /// <summary>
        /// Инициализация отрисовки фрактала
        /// </summary>
        /// <param name="graph">Куда отрисовывать</param>
        public override void Draw(System.Drawing.Graphics graph)
        {
            graph.FillRectangle(System.Drawing.Brushes.White, 0, 0, (xsize + space * 2) * scale, (ysize + space * 2) * scale);
            if (max_level_of_rec > 0)
            {
                this.colorarrmax = (max_level_of_rec + 1);
                this.colorarr = new Colorarr(colorarrmax, startColor, endColor);
                this.colorarrstep = bindrob(colorarrmax, 2, max_level_of_rec);
            }
            try
            {
                P p = new P((0 + this.xsize / 4 + space) * scale, (0 + this.xsize / 4 + space) * scale, (this.xsize / 2) * scale, "ulr", new Point((0 + this.xsize / 4 + this.xsize / 2 + space) * scale, (0 + this.xsize / 4 + space) * scale));
                Lines l = new Lines();
                rec(graph, p, 0, l);
            }
            catch (StackOverflowException)
            {
                message = "Слишком большая глубина рекусии (установите количество итераций для построения фрактала на меньшее значение";
            }
        }

        class P
        {
            public Point p1, p2, p3, p4, p5;
            public float w=0;
            public string direct="nnn";
            /// <summary>
            /// Конструктор без параметров
            /// </summary>
            public P() { }
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="x">Координата x начальной точки</param>
            /// <param name="y">Координата y начальной точки</param>
            /// <param name="w">Расстояние между точками</param>
            /// <param name="direct">Направление элемента</param>
            /// <param name="o">Следующая точка</param>
            public P(float x, float y, float w, string direct, Point o)
            {
                this.p5 = o;
                this.w = w;
                this.direct = direct;
                p1 = new Point(x, y);
                switch (direct)
                {
                    case "ulr":
                        p2 = new Point(x, y + w);
                        p3 = new Point(x + w, y + w);
                        p4 = new Point(x + w, y);
                        break;
                    case "url":
                        p2 = new Point(x, y + w);
                        p3 = new Point(x - w, y + w);
                        p4 = new Point(x - w, y);
                        break;
                    case "lud":
                        p2 = new Point(x + w, y);
                        p3 = new Point(x + w, y + w);
                        p4 = new Point(x, y + w);
                        break;
                    case "ldu":
                        p2 = new Point(x + w, y);
                        p3 = new Point(x + w, y - w);
                        p4 = new Point(x, y - w);
                        break;
                    case "rud":
                        p2 = new Point(x - w, y);
                        p3 = new Point(x - w, y + w);
                        p4 = new Point(x, y + w);
                        break;
                    case "rdu":
                        p2 = new Point(x - w, y);
                        p3 = new Point(x - w, y - w);
                        p4 = new Point(x, y - w);
                        break;
                    case "dlr":
                        p2 = new Point(x, y - w);
                        p3 = new Point(x + w, y - w);
                        p4 = new Point(x + w, y);
                        break;
                    case "drl":
                        p2 = new Point(x, y - w);
                        p3 = new Point(x - w, y - w);
                        p4 = new Point(x - w, y);
                        break;
                }
            }

            /// <summary>
            /// Нарисовать линии (p1,p2), (p2,p3), (p3,p4)
            /// </summary>
            /// <param name="g">Куда рисовать</param>
            /// <param name="pen">Чем рисовать</param>
            public void Drow(System.Drawing.Graphics g, System.Drawing.Pen pen)
            {
                g.DrawLine(pen, p1.x, p1.y, p2.x, p2.y);
                g.DrawLine(pen, p2.x, p2.y, p3.x, p3.y);
                g.DrawLine(pen, p3.x, p3.y, p4.x, p4.y);
            }
        }

        class Line {
            public float x1, y1, x2, y2;
            public char dir = ' ';
            /// <summary>
            /// Конструктор без параметров
            /// </summary>
            public Line() { }
            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="x1">Координата x начальной точки</param>
            /// <param name="y1">Координата y начальной точки</param>
            /// <param name="x2">Координата x конечной точки</param>
            /// <param name="y2">Координата y конечной точки</param>
            /// <param name="dir"></param>
            public Line(float x1, float y1, float x2, float y2, char dir)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.dir = dir;
            }
        }

        class Lines
        {
            public List<Line> l;
            /// <summary>
            /// Конструктор без параметров: создаёт пустой массив линий l
            /// </summary>
            public Lines()
            {
                l = new List<Line>();
            }
            /// <summary>
            /// Конструктор: принимает массив line и строит по нему массив l
            /// </summary>
            /// <param name="line">Массив линий - соединителей</param>
            public Lines(List<Line> line)
            {
                l = new List<Line>();
                foreach (Line li in line)
                {
                    switch (li.dir)
                    {
                        case 'u':
                            float wu = Math.Abs(li.x2 - li.x1);
                            l.Add(new Line(li.x1 + wu / 4, li.y1 - wu / 4, li.x2 - wu / 4, li.y2 - wu / 4, 'u'));
                            break;
                        case 'l':
                            float wl = Math.Abs(li.y2 - li.y1);
                            l.Add(new Line(li.x1 - wl / 4, li.y1 + wl / 4, li.x2 - wl / 4, li.y2 - wl / 4, 'l'));
                            break;
                        case 'd':
                            float wd = Math.Abs(li.x2 - li.x1);
                            l.Add(new Line(li.x1 - wd / 4, li.y1 + wd / 4, li.x2 + wd / 4, li.y2 + wd / 4, 'd'));
                            break;
                        case 'r':
                            float wr = Math.Abs(li.y2 - li.y1);
                            l.Add(new Line(li.x1 + wr / 4, li.y1 - wr / 4, li.x2 + wr / 4, li.y2 + wr / 4, 'r'));
                            break;
                    }
                }
            }


        }

        /// <summary>
        /// Рекурсивное вычисление и отрисовка фрактала
        /// </summary>
        /// <param name="g">Куда отрисовывать</param>
        /// <param name="p">Точки для отрисовки следующего шага</param>
        /// <param name="lor">Текущий уровень рекурсии</param>
        /// <param name="l">Массив линий</param>
        void rec(System.Drawing.Graphics g, P p, float lor, Lines l)
        {
            if (!isdrawing) return;
            if (lor == max_level_of_rec - 1)
            {
                this.summ += this.step;
                try
                {
                    lock (_vlock) { this.pb.progressBar1.Value = Math.Min(this.pbm - 3, (int)(this.summ)); }
                }
                catch (System.InvalidOperationException ex)
                {

                }
            }
            level_of_rec = (int)lor;
            if (lor == max_level_of_rec)
            {
                return;
            }

            if (max_level_of_rec > 0)
            {
                this.pen.Color = this.colorarr.colorarr[(int)(lor)];
            }
            p.Drow(g,pen);
            if (l.l.Count>0)
            {
                foreach (Line line in l.l)
                {
                    g.DrawLine(pen, line.x1, line.y1, line.x2, line.y2);
                }
            }

            if (p.w < 2 && !drawall && lor!=0)
            {
                    return;
            }

            //Start another recursions
            switch (p.direct[0]){
                case 'u':
                    Lines liu = l;
                    l = new Lines(liu.l);
                    l.l.Add(new Line(p.p1.x - p.w / 4, p.p1.y + p.w / 4, p.p2.x - p.w / 4, p.p2.y - p.w / 4, 'l'));
                    l.l.Add(new Line(p.p2.x + p.w / 4, p.p2.y - p.w / 4, p.p3.x - p.w / 4, p.p3.y - p.w / 4, 'u'));
                    l.l.Add(new Line(p.p3.x + p.w / 4, p.p3.y - p.w / 4, p.p4.x + p.w / 4, p.p4.y + p.w / 4, 'r'));
                    rec(g, new P(p.p1.x - p.w / 4, p.p1.y - p.w / 4, p.w / 2, "lud", new Point(p.p2.x - p.w / 4, p.p2.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p2.x - p.w / 4, p.p2.y - p.w / 4, p.w / 2, "ulr", new Point(p.p3.x - p.w / 4, p.p3.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p3.x - p.w / 4, p.p3.y - p.w / 4, p.w / 2, "ulr", new Point(p.p4.x + p.w / 4, p.p4.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p4.x + p.w / 4, p.p4.y + p.w / 4, p.w / 2, "rdu", new Point(p.p5.x + p.w / 4, p.p5.y - p.w / 4)), lor + 1, l);
                    break;
                case 'l':
                    Lines lil = l;
                    l = new Lines(lil.l);
                    l.l.Add(new Line(p.p1.x + p.w / 4, p.p1.y - p.w / 4, p.p2.x - p.w / 4, p.p2.y - p.w / 4, 'u'));
                    l.l.Add(new Line(p.p2.x - p.w / 4, p.p2.y + p.w / 4, p.p3.x - p.w / 4, p.p3.y - p.w / 4, 'l'));
                    l.l.Add(new Line(p.p3.x - p.w / 4, p.p3.y + p.w / 4, p.p4.x + p.w / 4, p.p4.y + p.w / 4, 'd'));
                    rec(g, new P(p.p1.x - p.w / 4, p.p1.y - p.w / 4, p.w / 2, "ulr", new Point(p.p2.x - p.w / 4, p.p2.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p2.x - p.w / 4, p.p2.y - p.w / 4, p.w / 2, "lud", new Point(p.p3.x - p.w / 4, p.p3.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p3.x - p.w / 4, p.p3.y - p.w / 4, p.w / 2, "lud", new Point(p.p4.x + p.w / 4, p.p4.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p4.x + p.w / 4, p.p4.y + p.w / 4, p.w / 2, "drl", new Point(p.p5.x - p.w / 4, p.p5.y - p.w / 4)), lor + 1, l);
                    break;
                case 'r':
                    Lines lir = l;
                    l = new Lines(lir.l);
                    l.l.Add(new Line(p.p1.x - p.w / 4, p.p1.y + p.w / 4, p.p2.x + p.w / 4, p.p2.y + p.w / 4, 'd'));
                    l.l.Add(new Line(p.p2.x + p.w / 4, p.p2.y - p.w / 4, p.p3.x + p.w / 4, p.p3.y + p.w / 4, 'r'));
                    l.l.Add(new Line(p.p3.x + p.w / 4, p.p3.y - p.w / 4, p.p4.x - p.w / 4, p.p4.y - p.w / 4, 'u'));
                    rec(g, new P(p.p1.x + p.w / 4, p.p1.y + p.w / 4, p.w / 2, "drl", new Point(p.p2.x + p.w / 4, p.p2.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p2.x + p.w / 4, p.p2.y + p.w / 4, p.w / 2, "rdu", new Point(p.p3.x + p.w / 4, p.p3.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p3.x + p.w / 4, p.p3.y + p.w / 4, p.w / 2, "rdu", new Point(p.p4.x - p.w / 4, p.p4.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p4.x - p.w / 4, p.p4.y - p.w / 4, p.w / 2, "ulr", new Point(p.p5.x + p.w / 4, p.p5.y + p.w / 4)), lor + 1, l);
                    break;
                case 'd':
                    Lines lid = l;
                    l = new Lines(lid.l);
                    l.l.Add(new Line(p.p1.x + p.w / 4, p.p1.y - p.w / 4, p.p2.x + p.w / 4, p.p2.y + p.w / 4, 'r'));
                    l.l.Add(new Line(p.p2.x - p.w / 4, p.p2.y + p.w / 4, p.p3.x + p.w / 4, p.p3.y + p.w / 4, 'd'));
                    l.l.Add(new Line(p.p3.x - p.w / 4, p.p3.y + p.w / 4, p.p4.x - p.w / 4, p.p4.y - p.w / 4, 'l'));
                    rec(g, new P(p.p1.x + p.w / 4, p.p1.y + p.w / 4, p.w / 2, "rdu", new Point(p.p2.x + p.w / 4, p.p2.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p2.x + p.w / 4, p.p2.y + p.w / 4, p.w / 2, "drl", new Point(p.p3.x + p.w / 4, p.p3.y + p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p3.x + p.w / 4, p.p3.y + p.w / 4, p.w / 2, "drl", new Point(p.p4.x - p.w / 4, p.p4.y - p.w / 4)), lor + 1, l);
                    rec(g, new P(p.p4.x - p.w / 4, p.p4.y - p.w / 4, p.w / 2, "lud", new Point(p.p5.x - p.w / 4, p.p5.y - p.w / 4)), lor + 1, l);
                    break;



            }

            if (lor == 0)
            {
                this.isdrawing = false;
                Fractal.handle.Set();
            }
        }
    }

}