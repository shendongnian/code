    int quantity;
    if(!Int32.TryParse(textBox9.Text, out quantity))
         MessageBox.Show("Invalid number");
    else
    {
        using(OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source=|DataDirectory|\\crepeDB.accdb;"))
        {    
            conn.Open();
            string query = @"insert into Sales (Sdate,SQuantity) 
                             values (@date, @qta)";
            OleDbCommand cmd = new OleDbCommand(query, conn);
            cmd.Parameters.Add("@date", OleDbType.Date).Value =  dateTimePicker1.Value;
            cmd.Parameters.Add("@qta", OleDbType.Integer).Value = quantity;
            cmd.ExecuteNonQuery();
        }
    }
