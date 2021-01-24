    using (var connection = new SqlConnection("your connection string here..."))
    {
        using (var command = new SqlCommand())
        {
            SqlDataReader reader;
            command.Connection = connection;
            // Next command is your query. 
            command.CommandText = "SELECT * FROM MyTable WHERE WebDateTime BETWEEN @Date1 AND @Date2";
            command.CommandType = CommandType.Text;
            var date1 = new SqlParameter("Date1", SqlDbType.Date);
            var date2 = new SqlParameter("Date2", SqlDbType.Date);
            date1.Value = new DateTime(2017, 2, 7, 20, 19, 0);
            date2.Value = new DateTime(2017, 2, 7, 1, 19, 0);
            command.Parameters.Add(date1);
            command.Parameters.Add(date2);
            connection.Open();
            reader = command.ExecuteReader();
            // Data is accessible through the DataReader object here.                 
        }
    }
