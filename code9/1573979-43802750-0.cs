        public myform()
        {
             InitializeComponent(); // this will be called in ComboBox ComboBox = new System.Windows.Forms.ComboBox();
             BindComboBox();
        }
        public void BindComboBox()
        {            
	        DataTable dt = new DataTable();
	        ComboBox.DataSource = dt;
            ComboBox.Items.Insert(0,"--Select--");
        }
