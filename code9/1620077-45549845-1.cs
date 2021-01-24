    public partial class Form1 : Form
    {
        private readonly DataProcessor dataProcessor = new DataProcessor();
        public Form1()
        {
            this.InitializeComponent();
        }
        private void button1Next_Click(object sender, EventArgs e)
        {
            this.buttonNext.Enabled = false;
            this.ProcessNext();
        }
        private async void ProcessNext()
        {
            string s = await this.dataProcessor.ProcessNext();
            this.textBoxP1Text1.Text = s;
            this.buttonNext.Enabled = true;
        }
    }
    public class DataProcessor
    {
        private readonly Random r = new Random(); // Or reader or whatever.
        public async Task<string> ProcessNext() // Just using `string` as an example.
        {
            await Task.Delay(1000);
            return this.r.Next().ToString();
        }
    }
