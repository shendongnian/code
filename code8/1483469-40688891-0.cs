           using (SqlCommand command = new SqlCommand("select * from OrderProduct where OrderProductID=@folder", conn))
            {
                command.Parameters.Add(new SqlParameter("@folder", folder));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        order[1] = Convert.ToString(reader.GetInt32(1));
                }
            }
