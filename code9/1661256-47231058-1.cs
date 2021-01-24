    using System;
    using System.Windows.Forms;
    
    namespace CommandLineParameters_47230955
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
    
                if (args.Length > 0)
                {
                    switch (args[0].ToLower())
                    {
                        case "triggerform1":
                            Application.Run(new Form1());
                            break;
                        case "triggerform2":
                            Application.Run(new Form2());
                            break;
                        default:
                            break;
                    }
                }
    
            }
    
        }
    }
