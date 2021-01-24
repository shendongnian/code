     public class MyDataBaseConnection
        {
            public DataTable ReturnMyData(string valueFromTextBox)
            {
            var cs = "Data Source=dataBase.sqlite;Version=3;";
            SQLiteConnection con;
            SQLiteDataAdapter adapt;
            DataTable dt;  
            try
             {
                con = new SQLiteConnection(cs);
                con.Open();
                adapt = new SQLiteDataAdapter("select * from Table1 where CnName1 like '" + textBox1.Text + "%'", con);
                dt = new DataTable();
                adapt.Fill(dt);
                con.Close();
                return dt;
             }
             catch (Exception ex)
             {
                //Log here.
                throw;
             }
             finally
             {
                con = null;
                adapt = null;
                //Or Dispose. I dont have SQL lite so dont know if they implement IDispose
             }
        }
    }
