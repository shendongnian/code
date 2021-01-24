    public partial class Form1 : Form
    {
        private readonly SemaphoreSlim signal = new SemaphoreSlim(0, int.MaxValue);
        public Form1()
        {
            this.InitializeComponent();
            this.RunLoop();
        }
        private async void RunLoop()
        {
            var i = 0;
            while (true)
            {
                this.label2.Text = $"Enqueued: {this.signal.CurrentCount}";
                await this.signal.WaitAsync(); // Wait button click async
                await Task.Delay(1000); // Simulate work
                this.label1.Text = $"Completed: {++i}";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.signal.Release();
            this.label2.Text = $"Enqueued: {this.signal.CurrentCount + 1}";
        }
    }
