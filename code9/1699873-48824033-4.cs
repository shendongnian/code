    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AllocConsole();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ConsoleApplication.Program.Main(new string[] {});
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
