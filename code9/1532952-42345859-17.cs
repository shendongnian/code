    public partial class Form1 : Form
    {
        Timer t = new Timer();
        public Form1()
        {
            InitializeComponent();
            t.Interval = 200;    // set the interval
            t.Tick += T_Tick;    // register to the event
        }
        int i = 0;  // this is your counting variable
        private void T_Tick(object sender, EventArgs e)
        {
            if (i<=20) // this takes care of the end
            {
                this.textBox1.Text = i.ToString();
                i++; // count up
            }
            else
            {
                t.Stop(); // stop the timer if finished
                i = 0;    // for the next time if you want to restart the timer
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();  // now just start your timer
        }
    }
