    DateTime timeIn;
    // I would rather use TryParseExact, I just don't know what format you expect...
    if(DateTime.TryParse(textBox2.Text, out timeIn)) 
    {
        using (var Connection = new SqlConnection(connectionString))
        {
            string query = "INSERT INTO Person (Name,Organisation,TimeIn) VALUES(@Name, @Organisation, @TimeIn)";
            using(var SignIn = new SqlCommand(query, Connection))
            {
                SignIn.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBox1.Text;
                SignIn.Parameters.Add("@Organisation", SqlDbType.NVarChar).Value = textBox3.Text;
                SignIn.Parameters.Add("@TimeIn", SqlDbType.DateTime).Value = timeIn;
                Connection.Open();
                SignIn.ExecuteNonQuery(); // this should be fine currently
            }
        }
    }
