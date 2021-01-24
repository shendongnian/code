    public partial class Reaction : Form
    {
        Stopwatch timer;
        bool start = false;
        public Reaction()
        {
            ...
        }
        public async Task Test()
        {
            if (start)
            {
                ...
            }
            else
            {
                Random rnd = new Random();
                int number = rnd.Next(1, 10000);
                // Replace Thread.Sleep with Task.Delay
                await Task.Delay(3000 + number);
                timer = Stopwatch.StartNew();
                button1.BackColor = Color.Green;
                button1.Text = "CLICK";
                start = true;
            }
        }
        // Make button1_Click not async and remove await
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            button1.Text = "Dont click";
            Test();
        }
    }
