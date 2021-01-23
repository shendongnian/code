    public void database_connect(Form1 form1, String item_code, String des, String unit, double price)
        {
          //Form1 f1 = new Form1();
            try
            {
    
                connect.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connect;
                command.CommandText = "INSERT into item (item_code, description, unit, price) values ('" + item_code + "', '" + des + "', '" + unit + "', " + price + ")";
                command.ExecuteNonQuery();
    
                connect.Close();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Source);
                connect.Close();
            }
           form1.refresh_dataGridView();
        }
