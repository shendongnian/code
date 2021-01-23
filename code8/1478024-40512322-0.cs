    List<State> states = new List<State>();
        using (SqlConnection connection = new SqlConnection("conn_string"))
        {
            string query = "SELECT Id, Code, Name FROM State";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        State state =  new State { Id = (int)reader["Id"], Code = reader["Code"].ToString(), Name = reader["Name"].ToString() };
                        states.Add(state);
                    }
                }
            }
        }
