    List<string> myData = new List<string>();
 
            using (SqlConnection connection = new SqlConnection("Your connection string"))
            {
                string query = "SELECT imgPath, heading, ... FROM pt_Tours_Index_Master";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        myData.Add(reader.GetString(0));
                        myData.Add(reader.GetString(1));
                        myData.Add(reader.GetString(2));
                        myData.Add(reader.GetString(3));
                }
                connection.Close();
            }
