    public static void AddData(DataGrid datagrid)
    {
        collection.Clear();
        using (SqlConnection connection = GetConnection())
        {
            using (SqlCommand command = new SqlCommand("Select req_status, req_date_time, resp_user_name From TH_request where req_status = 'N'", connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        collection.Add(new DataObject()
                        {
                            A = Convert.ToDateTime(reader["req_date_time"]),
                            B = Convert.ToString(reader["resp_user_name"]),
                            C = Convert.ToString(reader["req_status"]),
                            D = respUserName
                        });
                    }
                }
            }
        }
        datagrid.ItemsSource = collection;
    }
