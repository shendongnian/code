        public myform()
        {
             InitializeComponent(); // this will be called in ComboBox ComboBox = new System.Windows.Forms.ComboBox();
             BindComboBox();
        }
        public void BindComboBox()
        {            
	        comboBox1.SelectedItem = null;
            comboBox1.SelectedText = "--select--";
        }
