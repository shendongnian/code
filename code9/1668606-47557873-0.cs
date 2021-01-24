    try
            {
                
                connection.Open();
                command = new SqlCommand("UPDATE Content SET DateChecked=@DateChecked, CheckedOut=@CheckedOut WHERE MovieID=@MovieID", connection);
                command.Parameters.AddWithValue("@DateChecked", DateTime.Now);
                command.Parameters.AddWithValue("@CheckedOut", 'Y');
                //command.Parameters.AddWithValue("@MovieID",);
                command.Parameters.AddWithValue("@MovieID", CheckOutList.SelectedValue);
                //reader = command.ExecuteReader();
                command.ExecuteNonQuery();
                one_data.DataSource = reader;
                one_data.DataBind();
                connection.Close();
                
                connection.Open();
                command = new SqlCommand("INSERT INTO checkout (MovieID, SubscriberID) VALUES (@MovieID, @SubscriberID)", connection);
                command.Parameters.AddWithValue("@MovieID", CheckOutList.SelectedValue);
                command.Parameters.AddWithValue("@SubscriberID", loginName.Text);
                command.ExecuteNonQuery();
                //reader.Close();
            }
