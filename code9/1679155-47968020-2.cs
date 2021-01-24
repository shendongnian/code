        public string mytext; //Variable I want to use later, in Form2.
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mytext = tb1.Text;
            Form2 fm = new Form2(this);
            fm.ShowDialog();
        }
