    // This should actually be on a repository class
    public static FormTemplate GetFormTemplateById(int locationId)
    {
        string query =
                @"SELECT header, footer 
                  from registration_center_template t
                       Inner Join company_template tc ON t.id = tc.template_id
                  where tc.location_id =" + locationId;
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["appdb"]))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandTimeout = 3000;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.Read()
                        ? new FormTemplate
                            {
                                Header = reader["header"] as string,
                                Footer = reader["footer"] as string
                            }
                        : new FormTemplate(); // could also be null - preference;
                }
            }
        }
    }
