    namespace WindowsFormsApp1
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(filePath1);
            System.Diagnostics.Process.Start(filePath2);
        }
    }
    }
