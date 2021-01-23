        private void Form1_Load(object sender, EventArgs e)
        {           
            
            label1.Text = label2.Text = label3.Text = String.Empty;
            // strCon is connection string
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand("Select * from testTable", con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            con.Open();
            da.Fill(dt);
            con.Close();
          
            foreach (Control x in this.Panel1.Controls)
            {
                if (x is ComboBox)
                {
                    ((ComboBox)x).DataSource = new BindingSource(dt, null);
                    ((ComboBox)x).DisplayMember = "Name";
                    ((ComboBox)x).ValueMember = "Count";
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox2.SelectedValue.ToString();
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text = comboBox3.SelectedValue.ToString();
        }
