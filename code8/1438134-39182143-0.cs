    string query = @"SELECT * SMSMessage
                     WHERE respondCode  IS NULL
                     AND sentOn > @dateLimit";
    SqlConnection con = new SqlConnection(Utilities.getConnectionString());
    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.Add("@dateLimit", SqlDbType.DateTime).Value = new DateTime(2016, 8, 26);
