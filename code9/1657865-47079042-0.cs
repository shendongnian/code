        public Form1()
        {
            InitializeComponent();
            b = new Button() { Text = "Prueba" };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            AddButtonToTabControl();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddButtonToTabControl();
        }
        public void AddButtonToTabControl()
        {
            tabControl1.SelectedTab.Controls.Add(b);
        }
