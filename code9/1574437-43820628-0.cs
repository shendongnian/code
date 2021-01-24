     public partial class Form1 : Form
    {
        Timer timer = new Timer();
        private long Elapsed;
        public Form1()
        {
            InitializeComponent();
            // set interval to 1.5 seconds 1500 (milliseconds)
            timer.Interval = 1500;
            // set tick event withs will be runt every 1.5 seconds  1500 (milliseconds)
            timer.Tick += OnTimerTick;
            // start timer
            timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            // add 1500 milliseconds to elapsed 1500 = 1.5 seconds
            Elapsed += 1500;
            // check if 18 seconds have elapsed
            if (Elapsed == 18000)
            {
                // stop the timer if it is
                timer.Stop();
            }
            // update variable
        }
    }
