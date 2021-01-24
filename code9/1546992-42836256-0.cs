    using(var con = new SqlConnection("connectring"))
    using(var cmd = new SqlCommand("SELECT Name FROM Table WHERE Id = @Id", con))
    {
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = 1234; 
        con.Open();
        string name = (string) cmd.ExecuteScalar();
    }
