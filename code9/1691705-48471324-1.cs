    // At the top of your file, you'll need this to access the Timer:
    using System.Windows.Forms;
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Stopwatch stopwatch = new Stopwatch();
        private static readonly Timer Timer = new Timer { Interval = 100 };
        private void Form1_Load(object sender, EventArgs e)
        {
            btnStartStop.Text = "Start";
            Timer.Tick += Timer_Tick;  // This hooks up an event handler for the Tick event
            Timer.Start();
        }
        // This code executes every {Timer.Interval} millisecond when the timer is running
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (stopwatch == null) stopwatch = new Stopwatch();
            txtVrijeme.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\.ff");
        }
        
        // This method handles the button click. It changes the button text and starts
        // or stops the stopwatch, depending on whether the stopwatch is running
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                Timer.Stop();
                btnStartStop.Text = "Start";
            }
            else
            {
                stopwatch.Start();
                Timer.Start();
                btnStartStop.Text = "Stop";
            }
        }
    }
