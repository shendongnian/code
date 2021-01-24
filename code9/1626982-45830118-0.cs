    using (SqlDataReader reader = command.ExecuteReader())
    {
        if (reader.HasRows)
        {
            try
            {
                while (reader.Read())
                {
                    DateTime? minDate = reader.IsDBNull(0) ? (DateTime?)null : reader.GetDateTime(0);
                    if (minDate != null)
                    {
                        dateStart.MinDate = minDate.Value;
                        dateEnd.MinDate = minDate.Value;
                        dateStart.Value = minDate.Value;
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
