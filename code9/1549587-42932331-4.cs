    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            timer1.Start();
        }
        public void SetProgress()
        {
            if (this.InvokeRequired) //Should have been handled by SplashScreenHandler but check just in case.
                this.BeginInvoke(new Action(SetProgress));
            progressBar1.Increment(15);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(15);
            if (progressBar1.Value == 30) timer1.Stop();
        }
    }
