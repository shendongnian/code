    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                throw new ApplicationException("ASDF");
            }
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //AllocConsole();
                //Console.WriteLine("BOOO");
                //throw new ApplicationException("BOOOO");
                Application.Run(new Form1());
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AllocConsole();
    
        }
    }
