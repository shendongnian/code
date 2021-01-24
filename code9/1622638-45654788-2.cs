    public partial class frmClock : Form
    {
        private ClockBase _clock;
        public frmClock()
        {
            InitializeComponent();
            _clock = new NormalClock(); // Create a normal clock.
            _clock.Tick += Clock_Tick; // Subscribe to the clock Tick event.
        }
        private void Clock_Tick(object sender, ClockTickEventArgs e)
        {
            lblTime.Text = e.TimeString; // Set the label text.
        }
    }
