    private void BindGridView()
    {
        var tokens = new List<AccessToken>();
        using (var conn = new SqlConnection("Server=somedbserver;Database=somedatabase;User Id=someuser;Password=somepassword;"))
        {
            using (var command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = "SELECT Id, Token, Secret FROM Tokens";
                command.CommandType = System.Data.CommandType.Text;
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var token = new AccessToken();
                        token.Id = reader.GetInt32(0);
                        token.Token = reader.GetString(1);
                        token.Secret = reader.GetString(2);
                        tokens.Add(token);
                    }
                }
            }
        }
        GridView1.DataSource = tokens;
        GridView1.DataBind();
    }
