    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp6
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                var form1 = new Form1();
                var form2 = new Form2();
                Application.Run(new MultiFormContext(form1, form2));
            }
        }
        public class MultiFormContext : ApplicationContext
        {
            private int openForms;
            public MultiFormContext(Form1 form1, Form2 form2)
            {
                form1.FormClosed += (s, args) =>
                {
                    if (System.Threading.Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };
                form1.Controls.OfType<TrackBar>().First().Scroll += (sender, args) =>
                {
                    form2.Controls.OfType<TextBox>().First().Text = "Modified from Form1";
                };
                form1.Show();
    
                form2.FormClosed += (s, args) =>
                {
                    if (System.Threading.Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };
                form2.Controls.OfType<TrackBar>().First().Scroll += (sender, args) =>
                {
                    form1.Controls.OfType<TextBox>().First().Text = "Modified from Form2";
                };
                form2.Show();
            }
        }
    }
