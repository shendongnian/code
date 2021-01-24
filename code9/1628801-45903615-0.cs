        private bool UserNameOrPasswordExists(string userName, string password)
        {
            using (SqlConnection conn = new SqlConnection("your connection string"))
            {
                conn.Open();
                var query = "Select * from LOGINFORM where USERNAME='@USERNAME' or PASSWORD='@PASSWORD'";
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    comm.Parameters.AddWithValue("@USERNAME", userName);
                    comm.Parameters.AddWithValue("@PASSWORD", password);
                    var result = comm.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
