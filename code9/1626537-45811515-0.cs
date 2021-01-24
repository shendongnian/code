    string Query = @"select riq_num, department, item_name, item_unit, no_of_stock_out, itemtype 
                     from outputdet1 
                     where riq_num = @riq_num
                     or department= @department 
                     or item_name= @item_name
                     or item_unit= @item_unit
                     or no_of_stock_out = @no_of_stock_out 
                     or itemtype = @itemtype";
    using (OleDbConnection MyConn2 = new OleDbConnection(MyConnection2))
    {
        using (OleDbCommand MyCommand2 = new OleDbCommand(Query, MyConn2))
        {
            MyConn2.Open();
            MyCommand2.Parameters.Add("@riq_num", SqlDbType.Int).Value = textBox2.Text;
            MyCommand2.Parameters.Add("@department", SqlDbType.NVarChar).Value = comboBox1.Text;
            MyCommand2.Parameters.Add("@item_name", SqlDbType.NVarChar).Value = textBox4.Text;
            MyCommand2.Parameters.Add("@item_unit", SqlDbType.Int).Value = comboBox2.Text;
            MyCommand2.Parameters.Add("@no_of_stock_out", SqlDbType.Int).Value = textBox6.Text;
            MyCommand2.Parameters.Add("@itemtype", SqlDbType.NVarChar).Value = comboBox3.Text;
            // execute the query here
        }
    }
