    SqlConnection sqlConnection1 = new SqlConnection("Data Source=ComputerOne; Initial Catalog=TestDatabase;Integrated Security=False; User ID=test; Password=test123;");
    SqlCommand cmd = new SqlCommand();
    SqlDataReader reader;
    string cardID = "";
    string quantity="";
    
    using(sqlConnection1 = new SqlConnection("Data Source=ComputerOne; Initial Catalog=TestDatabase;Integrated Security=False; User ID=test; Password=test123;"))
    {
        sqlConnection1.Open();
    
        using(cmd = new SqlCommand())
        {
            cmd.CommandText = "Select * From Users Where CardID=" + "'" + user.CardID + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
    
            using(reader = cmd.ExecuteReader())
            {
    
    
                while (reader.Read())
                {
                    cardID = reader["CardID"].ToString();
                }
            }
        }
    
        using(cmd = new SqlCommand())
        {
            cmd.CommandText = "Select T1.CardID, T2.Title, Sum(T1.Quantity) as Quantity From CardTransactions as T1 JOIN Adds as T2 ON T1.AddsID = T2.AddsID Where T1.CardID =" + cardID + "AND T1.Type = 1 Group By T1.CardID, T2.Title";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = sqlConnection1;
    
            using(reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    quantity = reader["Quantity"].ToString();
                }
            }
        }
        sqlConnection1.Close();
    }
