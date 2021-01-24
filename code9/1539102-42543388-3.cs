    public partial class Form1 : Form
    {
        DateTime Expires = DateTime.MaxValue;
        bool Warning = false;   // if true, warn when less than 30 seconds
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 1000;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.SettingShutdown)
            {
                MessageBox.Show("Not properly shut down");
                if (!Authenticate())
                    Close();
                Properties.Settings.Default.SettingShutdown = true;
                Properties.Settings.Default.Save();
            }
            textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
        }
        private bool Authenticate()
        {
            FormPassword f = new FormPassword();
            DialogResult dr = DialogResult.OK;
            for (int i = 0; i < 3 && dr == DialogResult.OK && f.Password != "pass"; ++i)
                dr = f.ShowDialog() ;
            return f.Password == "pass";
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = Expires - DateTime.Now;
            Time.Text = ts.ToString("mm\\:ss");
            if (ts.TotalSeconds < 30)
                if (Warning)
                {
                    Warning = false;    // this must be before the MessageBox
                    MessageBox.Show("You have 30 seconds left!");
                }
            if (ts.TotalSeconds <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Expired");
                Properties.Settings.Default.SettingShutdown = true;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();     // save all the settings
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonOkay_Click(object sender, EventArgs e)
        {
            int NewInterval = 0;
            if (!Int32.TryParse(textBoxInterval.Text, out NewInterval))
            {
                MessageBox.Show("Not a number");
                return;
            }
            if (!Authenticate())
                return;
            Properties.Settings.Default.SettingInterval = NewInterval;
            Expires = DateTime.Now.AddMinutes(NewInterval);
            Warning = true;
            timer1.Start();
            Properties.Settings.Default.SettingShutdown = false;
            Properties.Settings.Default.Save();
        }
    }
