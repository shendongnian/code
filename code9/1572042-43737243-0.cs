     public class MyDataBaseConnection
        {
            public DataTable ReturnMyData(string valueFromTextBox)
            {
                con = new SQLiteConnection(cs);
                con.Open();
                adapt = new SQLiteDataAdapter("select * from Table1 where CnName1 like '" + textBox1.Text + "%'", con);
                dt = new DataTable();
                adapt.Fill(dt);
                con.Close();
    
                return dt;
            }
        }
