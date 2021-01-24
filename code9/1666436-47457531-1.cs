    List<double> columnData = new List<double>();
                using (SqlConnection connection = new SqlConnection("Server=EGC25199;Initial Catalog=LegOgSpass;Integrated Security=SSPI;Application Name=SQLNCLI11.1"))
                {
                    connection.Open();
                        string query = "SELECT * FROM [dbo].[floattable]";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                columnData.Add(reader.GetDouble(0));
    
                            }
                        }
                    }
                }
