     private void button3_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrEmpty(textBox8.Text))
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM bookdat WHERE");
            
            
           SqlCommand cmd = new SqlCommand(con);
            if (comboBox2.SelectedIndex == 0)
                {
                cmd.Parameters.AddWithValue("@fdata", textBox8.Text);
                sb.Append(" title=@fdata ");
            }
            else if (comboBox2.SelectedIndex == 1)
                {
                cmd.Parameters.AddWithValue("@fdata", textBox8.Text);
                sb.Append(" author=@fdata ");
                }
            else if (comboBox2.SelectedIndex == 2)
                {
                cmd.Parameters.AddWithValue("@fdata", textBox8.Text);
                sb.Append(" publication=@fdata ");
                }
            else if (comboBox2.SelectedIndex == 3)
                {
                cmd.Parameters.AddWithValue("@fdata", textBox8.Text);
                sb.Append(" accno=@fdata ");
                }
            else if (comboBox2.SelectedIndex == 4)
                {
                cmd.Parameters.AddWithValue("@fdata",int.Parse( textBox8.Text));
                sb.Append(" price=@fdata ");
                }
            else if (comboBox2.SelectedIndex == 5)
                {
                cmd.Parameters.AddWithValue("@fdata",int.Parse( textBox8.Text));
                sb.Append(" quantity=@fdata ");
                }
            cmd.CommandText  =sb.ToString();
            da = new SqlDataAdapter(cmd);
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                cmd.ExecuteNonQuery();
                dataGridView2.DataSource = dt;
                con.Close();
                if (dt.Rows.Count> 0)
                {
                    MessageBox.Show("Record Found!!");
                    comboBox2.Text = "";
                    textBox8.Text = "";
                }
                else
                {
                    MessageBox.Show("No Records Found!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        else
        {
            MessageBox.Show("Please Fill The Required Fields To Find Data !!");
        }
    }
