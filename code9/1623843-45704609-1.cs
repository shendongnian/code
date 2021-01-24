        //change return type from bool to AccountBalanceRequest    
        public AccountBalanceRequest AccountBalanceCheek(AccountBalanceRequest accountNumber)
            {
            	using (SqlConnection conn = new SqlConnection(ConnectionString))
            	{
            		conn.Open();
            		//use top 1 since you are only getting one record.
                    //let us use string interpolation, if you are working below C#6
                    //replace it with your previous value
            		var cmd = new SqlCommand($@"SELECT TOP 1
            										* 
            									FROM 
            										Current_Account_Details 
            									WHERE 
            										Account_Number ='{accountNumber.Account_Number}'", conn));
            		cmd.CommandType = CommandType.Text;
            		//use ExecuteReader to execute sql select
            		//ExecuteNonQuery is for update, delete, and insert.
            		var reader = cmd.ExecuteReader();
            		//read the result of the execute command.
            		while(reader.Read())
            		{
            			//assuming that your property is the same as your table schema. refer to your table schema Current_Account_Details
                       //assuming that your datatype are string... just do the conversion...
            			accountNumber.Account_Balance = reader["Account_Balance"].ToString();
            			accountNumber.Account_Fee = reader["Account_Fee"].ToString();
            			accountNumber.Account_Balance = reader["Account_Balance"].ToString();
            			accountNumber.Over_Draft_Limit = reader["Over_Draft_Limit"].ToString();
            		}
            		return accountNumber;
            	}
            }
