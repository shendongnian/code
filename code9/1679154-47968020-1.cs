        Form1 mfm;
        public Form2(Form1 mainfm)
        {
            InitializeComponent();
            mfm = mainfm;
        }
        public void button2_Click(object sender, EventArgs e)
        {
            //In this method I use the variable "mytext" wich is a Form1 variable.
            textBox1.Text = mfm.mytext;
        }
