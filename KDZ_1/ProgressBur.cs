using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KDZ_1;

namespace KDZ_1
{
    public partial class ProgressBur : Form
    {
        private Fractal frac;
        public bool isexit = false;
        public Timer timer = new Timer();


        public void gfrac(object f)
        {
            this.frac = (Fractal)f;
            init();
        }
        //private Bitmap bmp = null;
        public System.Windows.Forms.ProgressBar progressBar1 = new System.Windows.Forms.ProgressBar();
        public ProgressBur(Object f)
        {
            this.Closed += ProgressBurClosed;
            frac = (Fractal)f;
            InitializeComponent();
            init();
            //this.TopMost = true;
            this.Hide();
            this.Enabled = false;
            this.Visible = false;
            timer.Interval = 10; //интервал между срабатываниями 10 миллисекунд
            timer.Tick += new EventHandler(Draw);
        }

        public void init()
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = frac.max_length;
            //this.progressBar1.Step = 1;
        }
        
        public void Draw(object sender, EventArgs e)
        {
            //init();
            //this.Activate();
            //this.Show();
            //this.TopMost = true;
            //this.TopMost = true;
            //while (frac.isdrawing)
            //{
            //if (!frac.isdrawing) break;
            //this.progressBar1.Value = frac.pb.progressBar1.Value;
            //Invalidate();
            //}
            //this.Hide();
            //this.TopMost = false;
            Invalidate();
        }

        void ProgressBurClosed(object sender, EventArgs e)
        {
            //Do nothing
            return;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isexit)
            {
                frac.isdrawing=false;
                e.Cancel = true;
            }
            //Hide();
        }
    }
}
