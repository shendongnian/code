        DataView dataView = null; // <<< Difference #1
        private void Form1_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("targ", typeof(string));
            dt.Rows.Add("1", "Targ-1");  // example code - remove
            dt.Rows.Add("2", "Targ-2");  // example code - remove
            dt.Rows.Add("3", "Targ-3");  // example code - remove
            dt.Rows.Add("4", "Targ-4");  // example code - remove
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "targ";
            comboBox1.DataSource = dt;
            var bf = new DataTable("BF");
            bf.Columns.Add("id", typeof(string));  // example code - remove
            bf.Columns.Add("CustomerName", typeof(string));  // example code - remove
            bf.Columns.Add("Email", typeof(string));  // example code - remove
            bf.Columns.Add("Capital", typeof(string));  // example code - remove
            bf.Rows.Add("1", "Customer-1", "Email-1", "Capital-1");  // example code - remove
            bf.Rows.Add("1", "Customer-2", "Email-2", "Capital-1");  // example code - remove
            bf.Rows.Add("2", "Customer-3", "Email-3", "Capital-2");  // example code - remove
            bf.Rows.Add("3", "Customer-4", "Email-4", "Capital-3");  // example code - remove
            bf.Rows.Add("3", "Customer-5", "Email-5", "Capital-3");  // example code - remove
            bf.Rows.Add("3", "Customer-6", "Email-6", "Capital-3");  // example code - remove
            bf.Rows.Add("4", "Customer-7", "Email-7", "Capital-4");  // example code - remove
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = bf;
            dataView = bf.DefaultView;  // <<< Difference #2
            this.comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);  // <<< Difference #3
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Remove filter")
            {
                dataView.RowFilter = string.Empty;
            }
            else
            {
                dataView.RowFilter = string.Format("id = '{0}'", comboBox1.SelectedValue);   //  <<< Difference #4
            }
        }
  
