    private void button3_Click(object sender, EventArgs e)
        {
    
            MySqlParameter[] pms = new MySqlParameter[1];
            pms[0] = new MySqlParameter("uProdNo", MySqlDbType.Int32);
            pms[0].Value = Convert.ToInt32(ProdNo.Text);
    
            MySqlCommand command = new MySqlCommand();
    
            command.Connection = conString;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "pos_delete";
    
            command.Parameters.AddRange(pms);
    
            conString.Open();
            if (command.ExecuteNonQuery() == 1)
            {
                dt.Rows.Clear();
                MessageBox.Show("Deleted");
    
            }
            else
            {
                MessageBox.Show("Sorry nothing to be deleted");
            }
            conString.Close();
    
        }
