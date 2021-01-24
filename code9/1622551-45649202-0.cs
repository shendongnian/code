    public void Countmmm()
        {
            con.Open();
            string MysqlStringnow = "SELECT count(national_id) from cheque where national_id='" + textBox11.Text + "'";
            MySqlCommand mycqlcommandNow = new MySqlCommand(MysqlStringnow, con);
            Int32 Rows_count = Convert.ToInt32(mycqlcommandNow.ExecuteScalar());
            mycqlcommandNow.Dispose();
            textBox4.Text = Rows_count.ToString();
            con.Close();
        }
