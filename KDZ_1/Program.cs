using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace KDZ_1
{
    static class Program
    {
        public class MultiFormContext : ApplicationContext
        {
            private int openForms;
            public MultiFormContext(params Form[] forms)
            {
                openForms = forms.Length;

                foreach (var form in forms)
                {
                    form.FormClosed += (s, args) =>
                    {
                        //When we have closed the last of the "starting" forms, 
                        //end the program.
                        if (Interlocked.Decrement(ref openForms) == 0)
                            ExitThread();
                    };

                    form.Show();
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //for developer only
            bool debug = false;
            //Заставляем всех использовать английскую локаль
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            while (true)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new Form1());
                    ProgressBur pb = new ProgressBur(new Fractal());
                    Application.Run(new MultiFormContext(new Form1(pb), pb));
                    break;
                }
                catch (Exception ex)
                {
                    if (debug) // For developers only
                    {
                        Console.WriteLine("Произошла непредвиденная ошибка\n" + ex.Message + '\n' + ex.Source + '\n' + ex.StackTrace + '\n' + ex.ToString());
                        Console.WriteLine("\nДля выхода из программы нажмите ESC\n Для перезапуска программы - клавишу Enter");
                        if (Console.ReadKey(true).Key != ConsoleKey.Escape) continue;
                    }
                }
                if(debug) break;
            }
        }
    }
}
