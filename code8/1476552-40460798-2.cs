    public class database_function
    {
         public void InsertItem(String item_code, String des, String unit, double price)
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
             //f1.refresh_dataGridView();
            }
    
     public DataTable get_view()
        {
            connect.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connect;
            string query = "Select item_code, description, unit, price from item";
            command.CommandText = query;
    
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            connect.Close();
            return dt;
        }
   }
