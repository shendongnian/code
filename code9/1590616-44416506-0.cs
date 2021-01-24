    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer timer = new Timer();
        private DateTime timeout;
        private void Form1_Load(object sender, EventArgs e)
        {
            timeout = DateTime.Now.AddSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Interval = 250;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (State().Equals(Online))
            {
                onLine = true;
                operationCompleted();
                timer.Stop();
            }
            if (DateTime.Now > timeout)
            {
                timer.Stop();
                MessageBox.Show("Error");
            }
        }
        // rest of class code omitted
    }
