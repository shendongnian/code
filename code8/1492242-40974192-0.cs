     private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("INSERTNEW", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter [] par = new SqlParameter[4];
            par[0] = new SqlParameter("@COD", SqlDbType.VarChar, 50);
            par[0].Value = textBox1.Text;
            par[1] = new SqlParameter("@FERQ", SqlDbType.Int);
            par[1].Value = numericUpDown1.TextAlign;
            par[2] = new SqlParameter("@DATE_ET", SqlDbType.Date);
            par[2].Value = dateTimePicker1.Text;
            par[3] = new SqlParameter("@DATE_PROC", SqlDbType.Date);
            DateTime d1 = Convert.ToDateTime(dateTimePicker1.Text);
            int k =Convert.ToInt32(numericUpDown1.TextAlign);
            string r = d1.AddMonths(k).ToShortDateString();
            par[3].Value = r ;
            cmd.Parameters.AddRange(par);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("good add");
        }
