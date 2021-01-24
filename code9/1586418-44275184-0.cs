    private void button1_Click(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U1OP1S9\SQLEXPRESS;Initial Catalog=PaintStores;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("sp_saveIncomeExpense", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", comboBox12.SelectedValue);
            cmd.Parameters.AddWithValue("@description", textBox1.Text);
            cmd.Parameters.AddWithValue("@amount", textBox2.Text);
            cmd.Parameters.AddWithValue("@date", dateTimePicker12.Value);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved Successfully");
                this.Close();
            }
            if(System.Windows.Forms.Application.OpenForms["Main"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["Main"] as Main).BindIncomeExpense();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
