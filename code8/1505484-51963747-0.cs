	private int RetriveWorkRequestID()
        {
            try
            {
                string query = "SELECT NEXT VALUE FOR sqWorkRequests";
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int value = int.Parse(reader[0].ToString());
                            string date = DateTime.Now.ToString("yyMM");
                            WorkRequestID = Convert.ToInt32(date.ToString() + value.ToString("000000"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return WorkRequestsID;
        }
