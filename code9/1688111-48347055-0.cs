    using (SqlCommand sqlCom = new SqlCommand("INSERT INTO UserActivations VALUES(@UserId, @ActivationCode)"))
            {
                using (SqlDataAdapter sqlAdpt = new SqlDataAdapter())
                {
                    sqlCom.Parameters.AddWithValue("@UserId", userId);
                    sqlCom.Parameters.AddWithValue("@ActivationCode", activationCode);
                    sqlCom.Connection = sqlConn;
                    sqlConn.Open();
                    //here it is
                    sqlCom.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
