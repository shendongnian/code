    using System;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var input = "abcd";
                string[] arguments = {"S", "HC", "HNC"};
                var isValid = IsValid(input, arguments);
            }
    
            private static bool IsValid(string text, params string[] arguments)
            {
                return arguments.Any(s => s == text);
            }
        }
    }
