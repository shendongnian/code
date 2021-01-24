        public UserControl1()
        {
            InitializeComponent();
        }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.CheckBox1;
            checkBox2.Checked = Properties.Settings.Default.CheckBox2;
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            Properties.Settings.Default.CheckBox1 = checkBox1.Checked;
            Properties.Settings.Default.CheckBox2 = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }
