    public static AccountInfo GetAccountInfo(string accountNumber)
    {
        AccountInfo result = null;
        using(var conn = new NpgsqlConnection("..."))
        {
            conn.Open();
            using(var command = new NpgsqlCommand("SELECT * FROM sms.get_accounts_info(@AccountNumber); ", conn))
            {
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                using(var dr = command.ExecuteReader())
                {
                    if(dr.HasRows && dr.Read())
                    {
                        result = new AccountInfo { 
                            accountNumber = dr["accountNumber"].ToString(),
                            balance = dr["balance"].ToString(),
                            interestRate = Convert.ToInt32(dr["interestRate"]),
                            accountName = dr["accountName"].ToString(),
                            accountType = dr["accountType"].ToString()
                        };
                    }
                }
            }
        }
        return result;
    }
