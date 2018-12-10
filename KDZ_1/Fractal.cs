using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using KDZ_1;

namespace KDZ_1
{




    //class Color
    //{
    //    public Color() { }
    //    public System.Drawing.Color color;
    //}

    
    class Fractal
    {
        public static System.Threading.EventWaitHandle handle = new System.Threading.AutoResetEvent(false);
        protected static object _vlock = new object();
        public char f = 'f';
        public bool drawall = true;
        public int max_length, max_length2;
        public virtual int Max_length {
                get
            {
                return max_length;
            }
                set
            {
                max_length = binpow(2, Math.Min(value,(int)30));
                max_length2 = max_length;
            }
        }
        public float summ = 0, step = 0;
        public bool isdrawing = false;
        public float scale = 1;
        public ProgressBur pb;
        public int pbm;
        public bool scf = false, ecf = false;
        protected Colorarr colorarr;
        protected int colorarrmax;
        protected float colorarriter = 0, colorarrstep;
        //public float length;
        public Color startColor;
        public Color endColor;
        protected int level_of_rec;
        public int max_level_of_rec;
        public float space, xspace, yspace; //Rasstojanie do granitsi okna
        public float size, xsize, ysize; //Size of fractal
        public float xleft, yleft; //Left Upper point
        protected float pictureBoxXsize, pictureBoxYsize; //Size of window
        public string message = "";
        public System.Drawing.Pen pen;
        public System.Drawing.Brush brush;
        public Fractal() {
            //this.length = 100;
            this.startColor = Color.White;
            this.endColor = Color.White;
            this.level_of_rec = 0;
            this.max_level_of_rec = 1;
            size = 300;
            space = 10;
            xspace = 218;
            yspace = 0;
            xsize = ysize = 300;
        }

        /// <summary>
        /// Быстрое возведение в степень
        /// </summary>
        /// <param name="x">Число возводимое в степень</param>
        /// <param name="step">Степень</param>
        /// <returns></returns>
        public int binpow(int x, int step)
        {
            if (step == 0) return 1;
            if (step % 2 == 0)
            {
                int a = binpow(x, step / 2);
                if (a < 0)
                {
                    return -1;
                }
                return a * a;
            }
            else
            {
                int a = binpow(x, step - 1);
                if (a < 0)
                {
                    return -1;
                }
                return x * a;
            }
        }

        /// <summary>
        /// Деление числа
        /// </summary>
        /// <param name="max">Делимое</param>
        /// <param name="x">Делитель</param>
        /// <param name="step">Количество делений Делимого на делитель ( max/(x*x*x*x) для step = 4)</param>
        /// <returns></returns>
        public float bindrob(float max, int x, int step)
        {
            if (step == 1) return (float)(1.0 * max) / x;
            return bindrob((float)(max) / x, x, step - 1);
        }

        /// <summary>
        /// Установить новые размеры окна для фрактала
        /// </summary>
        /// <param name="x">Новая ширина окна</param>
        /// <param name="y">Новая высота окна</param>
        public void setpictureBoxsize(float x, float y)
        {
            this.pictureBoxXsize = x;
            this.pictureBoxYsize = y;
        }

        /// <summary>
        /// Функция для возможности установки значения в protected поле
        /// </summary>
        /// <param name="f"></param>
        public virtual void set_float(float f)
        {

        }

        public Fractal(int mlor) : this()
        {
            this.max_level_of_rec = mlor;
        }
        public Fractal(int mlor, float length) : this()
        {
            //this.length = length;
            this.max_level_of_rec = mlor;
        }
        public Fractal(int mlor, Color sc, Color ec) : this()
        {
            this.startColor = sc;
            this.endColor = ec;
            this.max_level_of_rec = mlor;
        }
        public Fractal(int mlor, float length, Color sc, Color ec) : this()
        {
            //this.length = length;
            this.startColor = sc;
            this.endColor = ec;
            this.max_level_of_rec = mlor;
        }
        public Fractal(int mlor, float length, Color sc, Color ec, float xs, float ys) : this()
        {
            //this.length = length;
            this.startColor = sc;
            this.endColor = ec;
            this.max_level_of_rec = mlor;
            this.xsize = xs;
            this.ysize = ys;
        }
        public Fractal(int mlor, float length, Color sc, Color ec, float xs, float ys, float size) : this()
        {
            //this.length = length;
            this.startColor = sc;
            this.endColor = ec;
            this.max_level_of_rec = mlor;
            this.xsize = xs;
            this.ysize = ys;
            this.size *= size / this.size;
            this.space *= size / this.size;
        }
        public virtual void Draw(System.Drawing.Graphics graph)
        {

        }
    }
    class Line
    {
        public Point start, end;
        public int wigth;
        public Line() { }
        public Line(Point start, Point end)
        {
            this.start = new Point(start);
            this.end = new Point(end);
        }
        public Line(int x_start, int y_start, int x_end, int y_end)
        {
            this.start = new Point(x_start, y_start);
            this.end = new Point(x_end, y_end);
        }
        public Line(int x_start, int y_start, int x_end, int y_end, int wigth)
        {
            this.start = new Point(x_start, y_start);
            this.end = new Point(x_end, y_end);
            this.wigth = wigth;
        }
    }
    class Point
    {
        public float x, y;
        public Point() { }
        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }
    }



}
