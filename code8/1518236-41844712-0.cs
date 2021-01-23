                while (reader.Read())
                {
                   if(!String.IsNullOrEmpty(unitValues.Text)){
                      unitValues.Text += ", ";
                   }
                   unitValues.Text += reader["name"].ToString();
                }
