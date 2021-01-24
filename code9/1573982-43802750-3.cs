        public myform()
        {
             InitializeComponent(); // this will be called in ComboBox ComboBox = new System.Windows.Forms.ComboBox();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDataSet.someTable' table. You can move, or remove it, as needed.
            this.myTableAdapter.Fill(this.myDataSet.someTable);
            comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "--select--";           
        }
