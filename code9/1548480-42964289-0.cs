        private string Get_Balance(string AccountNumber)
        {
            string sql = "SELECT balance FROM account WHERE custid = @AccountID";
            string balance = "";
            using (OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.ConnectionScring))
            {
                OleDbCommand command = new OleDbCommand(sql, connection);
                command.Parameters.AddWithValue("@AccountID", AccountNumber);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        balance = reader["balance"].ToString();
                    }
                }
            }
            return (balance);
        }
