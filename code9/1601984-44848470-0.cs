                String longitude = "";
                String latitude = "";
                bool status = false;
                String path = "";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        longitude = reader["longitude"].ToString();
                        latitude = reader["latitude"].ToString();
                        status = (bool) reader["status"];
                        path = reader["path"].ToString();
                    }
                }
                Console.WriteLine("Longitude : " + longitude);
                Console.WriteLine("Latitude : " + latitude);
                Console.WriteLine("Path : " + path);
  
