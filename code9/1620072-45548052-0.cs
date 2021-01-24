    public partial class Form1 : Form
    {
        private readonly SemaphoreSlim signal = new SemaphoreSlim(0, 1);
        public Form1()
        {
            this.InitializeComponent();
            this.RunLoop();
        }
        private async Task RunLoop()
        {
            var i = 0;
            while (true)
            {
                await this.signal.WaitAsync(); // Wait for button click
                this.label1.Text = (++i).ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.signal.Release();
        }
    }
