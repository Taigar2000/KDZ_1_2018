using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KDZ_1
{
    public partial class Form1 : Form
    {
        private float posx, posy, pox, poy;
        Fractal frac;
        private string name = "";
        Fractal Frac{
            get{
                return frac;
            }
            set
            {
                pox = poy = 0;
                frac = value;
            }
        }
        private string message = "";
        private Bitmap bmp = null;
        private bool draw_step_by_step = true;
        ProgressBur pb;
        Timer timer = new Timer();
        bool fenableformwhendrawing = false;
        bool flagmb = false;


        /// <summary>
        /// Конструктор принимающий ссылку на окно шкалы прогресса
        /// </summary>
        /// <param name="pb">Ссылка на окно шкалы прогресса</param>
        internal Form1(ProgressBur pb)
        {
            this.pb = pb;
            this.pb.Visible = false;
            this.pb.Enabled = false;
            DoubleBuffered = true;
            InitializeComponent();
            Invalidate();
            Init();
            SetStartColor.Visible = false;
            SetEndColor.Visible = false;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.Color = Color.White;
            this.Closed += Form1Closed;
            this.TopMost = overAllWindowsToolStripMenuItem.Checked;
            timer.Interval = 10; //интервал между срабатываниями 10 миллисекунд
            timer.Tick += new EventHandler(timer_Tick);
            
        }

        /// <summary>
        /// Выбор фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_fractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox_type_of_fractal.SelectedIndex)
            {
                case 2:
                    this.textBox_dspace.Visible = true;
                    this.label_dspace.Visible = true;
                    Fractal Frac2 = Frac;
                    Frac = new Cantor();
                    if (Frac2 != null)
                    {
                        Frac.startColor = Frac2.startColor;
                        Frac.endColor = Frac2.endColor;
                        Frac.scf = Frac2.scf;
                        Frac.ecf = Frac2.ecf;
                        Frac.drawall = Frac2.drawall;
                        Frac.scale = Frac2.scale;
                    }
                    else
                        Init(false);
                    break;
                case 1:
                    this.textBox_dspace.Visible = false;
                    this.label_dspace.Visible = false;
                    Fractal Frac21 = Frac;
                    Frac = new Levi();
                    if (Frac21 != null)
                    {
                        Frac.startColor = Frac21.startColor;
                        Frac.endColor = Frac21.endColor;
                        Frac.scf = Frac21.scf;
                        Frac.ecf = Frac21.ecf;
                        Frac.drawall = Frac21.drawall;
                        Frac.scale = Frac21.scale;
                    }
                    else
                        Init(false);
                    break;
                case 0:
                    this.textBox_dspace.Visible = false;
                    this.label_dspace.Visible = false;
                    Fractal Frac22 = Frac;
                    Frac = new Gilbert();
                    if (Frac22 != null)
                    {
                        Frac.startColor = Frac22.startColor;
                        Frac.endColor = Frac22.endColor;
                        Frac.scf = Frac22.scf;
                        Frac.ecf = Frac22.ecf;
                        Frac.drawall = Frac22.drawall;
                        Frac.scale = Frac22.scale;
                    }
                    else
                        Init(false);
                    break;
                case -1:
                    return;
            }
            pb.gfrac(Frac);
            SetStartColor.Visible = true;
            SetEndColor.Visible = true;
        }

        /// <summary>
        /// Отрисовка фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Frac == null) { DropExWindow("Выберите тип фрактала"); return; }
            if (this.Frac.isdrawing) return;
            DrawFractal();
        }

        /// <summary>
        /// Построение фрактала
        /// </summary>
        void DrawFractal()
        {
            if (Frac!=null && Frac.isdrawing) return;
            bool f = false;
            message = "";
            if (Frac == null)
            {
                f = true;
            }
            this.textBox_dspace.Visible = false;
            this.label_dspace.Visible = false;
            switch (this.comboBox_type_of_fractal.SelectedIndex)
            {
                case 0: 
                    break;
                case 1:
                    break;
                case 2:
                    this.textBox_dspace.Visible = true;
                    this.label_dspace.Visible = true;
                    int dspace;
                    if (this.textBox_dspace.TextLength == 0)
                    {
                        //Вывод окна с сообщением об ошибке
                        DropExWindow("Введите расстояния между шагами рекурсии");
                        return;
                    }
                    if (this.textBox_dspace.TextLength == 0 || !int.TryParse(this.textBox_dspace.Text, out dspace) || dspace < 0 || dspace > 1000)
                    {
                        //Вывод окна с сообщением об ошибке
                        DropExWindow("Некорректный формат введённго расстояния между шагами рекурсии");
                        return;
                    }
                    Frac.set_float(dspace);
                    break;
            }
            if (Frac == null)
            {
                //Вывод окна с сообщением об ошибке
                message = "Выберите тип фрактала";
                DropExWindow(message);
                return;
            }if (!Frac.scf)
            {
                //Вывод окна с сообщением об ошибке
                message = "Выберите начальный цвет фрактала";
                DropExWindow(message);
                return;
            }
            if (!Frac.ecf)
            {
                //Вывод окна с сообщением об ошибке
                message = "Выберите конечный цвет фрактала";
                DropExWindow(message);
                return;
            }
            if (this.textBox_max_depth_of_rec.TextLength == 0 || !int.TryParse(this.textBox_max_depth_of_rec.Text, out Frac.max_level_of_rec) || Frac.max_level_of_rec <= 0 /*|| Frac.max_level_of_rec > 1000*/)
            {
                //Вывод окна с сообщением об ошибке
                this.message = "Некорректный формат глубины рекурсии";
                DropExWindow(message);
                return;
            }
            textBox1_TextChanged();
            draw_step_by_step = checkBox_buffer.Checked;
            if (f) Init();
            try
            {
                this.checkBox1.Enabled = false;
                this.comboBox_type_of_fractal.Enabled = false;
                this.SetStartColor.Enabled = false;
                this.SetEndColor.Enabled = false;
                this.textBox_max_depth_of_rec.Enabled = false;
                this.textBox_dspace.Enabled = false;
                this.button1.Enabled = false;
                this.textBox1.Enabled = false;
                this.button2.Enabled = false;
                this.toolStripMenuItem1.Enabled = false;
                this.bmp = new Bitmap((int)((Frac.xsize + Frac.space * 2) * Frac.scale), (int)((Frac.ysize + Frac.space * 2) * Frac.scale));
                Graphics graph = Graphics.FromImage(bmp);
                Frac.drawall = checkBox1.Checked;
                Frac.pen = new Pen(Frac.startColor);
                Frac.brush = new SolidBrush(Frac.startColor);
                this.Enabled = false || fenableformwhendrawing;
                this.TopMost = false;
                this.pb.Show();
                this.pb.TopMost = true;
                ProgressBur();
                timer.Start();
                Frac.pb.timer.Start();
                System.Threading.Thread thr = new System.Threading.Thread(delegate() { Frac.Draw(graph); });
                thr.Start();
                if (Frac.message.Length > 0)
                {
                    //Вывод окна с сообщением об ошибке
                    message = Frac.message;
                    DropExWindow(message);
                }
            }
            catch(NullReferenceException ex)
            {
                DropExWindow(ex.Message);
            }
            catch(OverflowException ex)
            {
                DropExWindow(ex.Message);
            }
            catch(ArgumentNullException ex)
            {
                DropExWindow("Введёно слишком большое приближение/удаление\n" + ex.Message);
                Init();
            }
            catch(Exception ex)
            {
                DropExWindow(""+ex.Message);
                Init();
            }
            finally
            {
            }
        }

        /// <summary>
        /// Переопределение перерисовки окна
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                if (bmp != null && Frac != null)
                {
                    e.Graphics.DrawImage(bmp, posx, posy);
                }
                base.OnPaint(e);
            }
            catch(ArgumentNullException ex)
            {
                //Вывод окна с сообщением об ошибке
                DropExWindow("Попытка вывести несуществующий фрактал" + ex.Message);
                //Данное сообщение можно было получить в предыдущих версиях программы
            }
            catch(OverflowException ex)
            {
                //Вывод окна с сообщением об ошибке
                //Text = "" + (posx + Frac.xspace) + " " + (posy + Frac.yspace) + " " + (Frac.scale);
                DropExWindow("" + ex.Message);
            }
            catch(Exception ex)
            {
                DropExWindow("" + ex.Message);
            }
        }

        bool f = false;
        /// <summary>
        /// ЛКМ нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_fractal_MouseDown(object sender, MouseEventArgs e)
        {
            if (Frac == null || (Frac.isdrawing && !fenableformwhendrawing)) return;
            if (!f)
            {
                pox = e.X;
                poy = e.Y;
                f = true;
                return;
            }
            else
            {
                
            }
        }

        /// <summary>
        /// ЛКМ отпущена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_fractal_MouseUp(object sender, MouseEventArgs e)
        {
            if (Frac == null || (Frac.isdrawing && !fenableformwhendrawing)) return;
            if (f)
            {
                f = false;
            }
        }

        /// <summary>
        /// Перемещение курсора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_fractal_MouseMove(object sender, MouseEventArgs e)
        {
            if (Frac == null || (Frac.isdrawing && !fenableformwhendrawing)) return;
            if (f)
            {
                float dx = e.X - pox, dy = e.Y - poy;
                pox += dx;
                poy += dy;
                posx += dx;
                posy += dy;

                if (posx > this.Width) posx = this.Width;
                if (posx - pictureBox1.Width + (2*Frac.space + Frac.xsize)*Frac.scale < 0) posx = pictureBox1.Width - (2 * Frac.space + Frac.xsize) * Frac.scale;
                if (posy + menuStrip1.Height > this.Height) posy = - menuStrip1.Height + this.Height;
                if (posy - menuStrip1.Height + (2 * Frac.space + Frac.ysize) * Frac.scale < 0) posy = menuStrip1.Height - (2 * Frac.space + Frac.ysize) * Frac.scale;

                Invalidate();
            }
        }

        /// <summary>
        /// Отцентровать изображение и сбросить масштаб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (Frac == null || Frac.isdrawing) return;
            if (this.Frac.isdrawing) return;
            Init();
        }

        /// <summary>
        /// Отлов нажатий клавиш
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Frac == null || Frac.isdrawing) return;
            if (e.KeyCode == Keys.C)
            {
                if (this.Frac.isdrawing) return;
                Init();
            }
            if (e.KeyCode == Keys.E)
            {
                if (this.Frac.isdrawing) return;
                ZoomUp();
                if (Frac == null)
                {
                    this.textBox1.Text = "1";
                }
                else
                {
                    this.textBox1.Text = $"{this.Frac.scale:f3}";
                }
            }
            if (e.KeyCode == Keys.Q)
            {
                if (this.Frac.isdrawing) return;
                ZoomDown();
                this.label5.Text = $"Масштаб: ";
                if (Frac == null)
                {
                    this.textBox1.Text = "1";
                }
                else
                {
                    this.textBox1.Text = $"{this.Frac.scale:f3}";
                }
            }
            if (e.KeyCode == Keys.B)
            {
                if (this.Frac.isdrawing) return;
                if (checkBox_buffer.Checked)
                {
                    DoubleBuffered = false;
                    checkBox_buffer.Checked = false;
                }
                else
                {
                    DoubleBuffered = true;
                    checkBox_buffer.Checked = true;
                }
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (this.Frac.isdrawing) return;
                Rewrite();
            }
            if (e.KeyCode == Keys.L && this.textBox1.Text=="42" && this.textBox_max_depth_of_rec.Text=="42")
            {
                fenableformwhendrawing ^= true;
                DropExWindow("В чём заключается смысл Жизни: "+(fenableformwhendrawing?"42":"I dont know"));
            }
        }

        /// <summary>
        /// Выбор начального цвета фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetStart_Click(object sender, EventArgs e)
        {
            if (this.Frac.isdrawing) return;
            colorDialog1.FullOpen = true;
            colorDialog1.Color = Frac.startColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Frac.startColor = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
                ((Button)sender).ForeColor = Color.FromArgb(((Button)sender).ForeColor.A, 
                    colorDialog1.Color.R < 128 ? 255 : 0,
                    colorDialog1.Color.G < 128 ? 255 : 0,
                    colorDialog1.Color.B < 128 ? 255 : 0);
                Frac.scf = true;
            }
            
        }

        /// <summary>
        /// Выбор конечного цвета фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetEndColor_Click(object sender, EventArgs e)
        {
            if (this.Frac.isdrawing) return;
            colorDialog1.FullOpen = true;
            colorDialog1.Color = Frac.endColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Frac.endColor = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
                ((Button)sender).ForeColor = Color.FromArgb(((Button)sender).ForeColor.A,
                    colorDialog1.Color.R < 128 ? 255 : 0,
                    colorDialog1.Color.G < 128 ? 255 : 0,
                    colorDialog1.Color.B < 128 ? 255 : 0);
                Frac.ecf = true;
            }
        }

        /// <summary>
        /// Приближение в конкретной точке
        /// </summary>
        /// <param name="e"></param>
        void ZoomUp(MouseEventArgs e)
        {
            if (this.Frac.isdrawing) return;
            pox -= (posx - e.X) - (posx - e.X) * (float)(1.5);
            poy -= (posy - e.Y) - (posy - e.Y) * (float)(1.5);
            posx -= (posx - e.X) - (posx - e.X) * (float)(1.5);
            posy -= (posy - e.Y) - (posy - e.Y) * (float)(1.5);
            Frac.scale *= (float)1.5;
            //Rewrite();
        }
        
        /// <summary>
        /// Приближение в левом верхнем углу
        /// </summary>
        void ZoomUp()
        {
            if (this.Frac.isdrawing) return;
            Frac.scale *= (float)1.5;
            this.textBox1.Text = Frac.scale.ToString();
            Rewrite();
        }

        /// <summary>
        /// Удаление в конкретной точке
        /// </summary>
        /// <param name="e"></param>
        void ZoomDown(MouseEventArgs e)
        {
            if (this.Frac.isdrawing) return;
            Frac.scale /= (float)1.5;
            pox -= (posx - e.X) - (posx - e.X) / (float)(1.5);
            poy -= (posy - e.Y) - (posy - e.Y) / (float)(1.5);
            posx -= (posx - e.X) - (posx - e.X) / (float)(1.5);
            posy -= (posy - e.Y) - (posy - e.Y) / (float)(1.5);
            //Rewrite();
        }

        /// <summary>
        /// Удаление в левом вехнем углу экрана
        /// </summary>
        void ZoomDown()
        {
            if (this.Frac.isdrawing) return;
            Frac.scale /= (float)1.5;
            this.textBox1.Text = Frac.scale.ToString();
            Rewrite();
        }

        /// <summary>
        /// Масштабирование изображения с помощью колёсика мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pictureBox_fractal_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.Frac.isdrawing) return;
            if (Frac == null || Frac.isdrawing) return;
            if (Frac == null || bmp == null) return;
            if (Frac.isdrawing) return;
            if (e.Delta > 0)
            {
                ZoomUp(e);
            }
            else
            {
                ZoomDown(e);
            }
            this.label5.Text = $"Масштаб: ";
            if (Frac == null)
            {
                this.textBox1.Text = "1";
            }
            else
            {
                this.textBox1.Text = $"{this.Frac.scale:f3}";
            }
            Rewrite();
        }

        /// <summary>
        /// Перерисовываем фрактал
        /// </summary>
        void Rewrite()
        {
            if (this.Frac.isdrawing) return;
            try
            {
                this.bmp = new Bitmap((int)(((Frac.xsize + Frac.space * 2) * Frac.scale)), (int)((Frac.ysize + Frac.space * 2) * Frac.scale));
                Graphics graph = Graphics.FromImage(bmp);
                DrawFractal();
            }
            catch (ArgumentNullException ex)
            {
                //Исключение выбрасываемое в предыдущих версиях программы
            }
            catch (System.ArgumentException ex)
            {
                //Вывод окна с сообщением об ошибке
                DropExWindow("Слишком большое приближение/удаление \n" + ex.Message);
                Init();
            }
            catch (OverflowException ex)
            {
                //Вывод окна с сообщением об ошибке
                DropExWindow("Слишком большая глубина рекурсии \n" + ex.Message);
            }
            catch (Exception ex)
            {
                DropExWindow("\n" + ex.Message);
            }
            Invalidate();
        }

        /// <summary>
        /// Сохранение изображения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Length == 0)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    bmp.Save("" + name, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (NullReferenceException ex)
            {
                DropExWindow("Невозможно сохранить несуществующий оъект\n" + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (Exception ex)
            {
                DropExWindow("" + ex.Message);
            }
        }

        /// <summary>
        /// Сохранение изображения как (старый интерфейс)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    name = FBD.SelectedPath;
                    bmp.Save("" + name, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (NullReferenceException ex)
            {
                DropExWindow("Невозможно сохранить несуществующий оъект\n" + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (Exception ex)
            {
                DropExWindow("" + ex.Message);
            }
        }

        /// <summary>
        /// Сохранение изображения как (новый интерфейс)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Frac == null) throw (new NullReferenceException());
                SaveFileDialog FBD = new SaveFileDialog();
                FBD.Filter = "Изображения (*.bmp)|*.bmp|Все файлы (*.*)|*.*";
                if (FBD.ShowDialog() == DialogResult.OK)
                {
                    name = FBD.FileName;
                    bmp.Save("" + name, System.Drawing.Imaging.ImageFormat.Bmp);
                }
            }
            catch (NullReferenceException ex)
            {
                DropExWindow("Невозможно сохранить несуществующий оъект\n" + ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (ArgumentException ex)
            {
                DropExWindow("Невозможно сохранить оъект\n" + ex.Message);
            }
            catch (Exception ex)
            {
                DropExWindow("" + ex.Message);
            }
        }

        /// <summary>
        /// Новое окно фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Frac!=null && this.Frac.isdrawing) return;
            (new Form1(pb)).ShowDialog(new Form1(pb));
        }
        
        /// <summary>
        /// Сколько уровней рекурсии отрисовывать
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Frac != null && !this.Frac.isdrawing) Frac.drawall = checkBox1.Checked;
        }

        /// <summary>
        /// Изменение масштаба через поле для ввода
        /// </summary>
        private void textBox1_TextChanged()
        {
            //if (this.Frac.isdrawing) return;
            float sc;
            if (!(float.TryParse(this.textBox1.Text, out sc) && sc > 0.05 && sc <= 51.8)) { DropExWindow("Неверное значение масштаба"); Init(false); return; }
            if (Frac == null) return;
            Frac.xspace = this.pictureBox1.Width;
            Frac.yspace = 22;
            Frac.xleft = posx;
            Frac.yleft = posy;
            Frac.scale = sc;
            if (!Frac.scf || !Frac.ecf) return;
        }

        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        /// <param name="s"></param>
        void DropExWindow(string s)
        {
            if (flagmb) return;
            flagmb = true;
            if(MessageBox.Show(s) == DialogResult.OK)
            {
                flagmb = false;
            }
        }

        /// <summary>
        /// Новое окно ожидания
        /// </summary>
        private void ProgressBur()
        {
            Frac.isdrawing = true;
            Frac.Max_length = (Frac.max_level_of_rec);
            Frac.step = (float)(10000.0) / Frac.Max_length;
            Frac.max_length = 10000;
            this.Frac.pbm = this.Frac.max_length;
            Frac.summ = 0;
            Frac.pb = this.pb;
            Frac.pb.init();
            Frac.pb.gfrac(Frac);
        }

        /// <summary>
        /// Отрисовка формы во время построения фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e)
        {
            if(draw_step_by_step) Invalidate();
            if (!Frac.isdrawing) end_of_Draw_Fractal();
        }

        /// <summary>
        /// Отрисовывать все уровни постепенно?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_buffer_CheckedChanged(object sender, EventArgs e)
        {
            draw_step_by_step = checkBox_buffer.Checked;
        }

        /// <summary>
        /// Конец отрисовки фрактала
        /// </summary>
        void end_of_Draw_Fractal() {
            this.Enabled = true;
            Frac.isdrawing = false;
            this.pb.Hide();
            this.pb.TopMost = false;
            this.Frac.pb.Hide();
            this.Frac.pb.TopMost = false;
            this.TopMost = overAllWindowsToolStripMenuItem.Checked;
            timer.Stop();
            Frac.pb.timer.Stop();
            this.checkBox1.Enabled = true;
            this.comboBox_type_of_fractal.Enabled = true;
            this.SetStartColor.Enabled = true;
            this.SetEndColor.Enabled = true;
            this.textBox_max_depth_of_rec.Enabled = true;
            this.textBox_dspace.Enabled = true;
            this.button1.Enabled = true;
            this.textBox1.Enabled = true;
            this.button2.Enabled = true;
            this.toolStripMenuItem1.Enabled = true;
            Invalidate();
        }

        /// <summary>
        /// Изменение выбранности пункта меню Поверх остальных окон и статуса Поверх остальных окон основного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void overAllWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overAllWindowsToolStripMenuItem.Checked ^= true;
            TopMost = overAllWindowsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Стартовые значения позиции и размера и перерисование фрактала
        /// </summary>
        private void Init()
        {
            if (Frac == null) return;
            if (this.Frac.isdrawing) return;
            Frac.xspace = this.pictureBox1.Width;
            Frac.yspace = 22;
            //posx = Frac.xspace - Frac.xsize * Frac.scale / 2 + (this.Width - Frac.xspace) / 2;
            //posy = Frac.yspace - Frac.ysize * Frac.scale / 2 + (this.Height - Frac.yspace * 2) / 2;
            posx = Frac.xspace;
            posy = Frac.yspace;
            Frac.xleft = posx;
            Frac.yleft = posy;
            Frac.scale = 1;
            this.textBox1.Text = Frac.scale.ToString();
            if (!Frac.scf || !Frac.ecf) return;
            DrawFractal();
            Invalidate();
        }

        /// <summary>
        /// Стартовые значения позиции и размера и если draw, то перерисование фрактала
        /// </summary>
        /// <param name="draw">Перерисовать фрактал?Да:Нет</param>
        private void Init(bool draw)
        {
            if (this.Frac.isdrawing) return;
            if (Frac == null) return;
            Frac.xspace = this.pictureBox1.Width;
            Frac.yspace = 22;
            //posx = Frac.xspace - Frac.xsize * Frac.scale / 2 + (this.Width - Frac.xspace) / 2;
            //posy = Frac.yspace - Frac.ysize * Frac.scale / 2 + (this.Height - Frac.yspace * 2) / 2;
            posx = Frac.xspace;
            posy = Frac.yspace;
            Frac.xleft = posx;
            Frac.yleft = posy;
            Frac.scale = 1;
            this.textBox1.Text = Frac.scale.ToString();
            if (!Frac.scf || !Frac.ecf) return;
            if (draw)
            {
                DrawFractal();
                Invalidate();
            }
        }

        /// <summary>
        /// Закрытие приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1Closed(object sender, EventArgs e)
        {
            if (Frac == null || Frac.pb == null)
            { 
                pb.isexit = true;
            }
            else
            {
                Frac.isdrawing = false;
                Frac.pb.isexit = true;
                Fractal.handle.WaitOne();
            }
            Dispose();
            Application.Exit();
        }
        
    }

}
