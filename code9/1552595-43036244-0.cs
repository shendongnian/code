        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.CheckBox1;
            checkBox2.Checked = Properties.Settings.Default.CheckBox2;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.CheckBox1 = checkBox1.Checked;
            Properties.Settings.Default.CheckBox2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }
