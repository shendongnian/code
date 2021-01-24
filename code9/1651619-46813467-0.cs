    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void RunWorker()
        {
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Utility.RunWorkerOfForm1();
        }
    }
    public static class Utility
    {
        public static void RunWorkerOfForm1()
        {
            var target = (Form1)Application.OpenForms.OfType<Form1>().FirstOrDefault();
            target?.RunWorker();
        }
    }
