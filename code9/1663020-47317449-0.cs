    using (var connection = new SqlConnection("Server=SQLServerName;Integrated Security=True;"))
    {
        try
        {
            connection.Open()
        }
        catch (Exception ex)
        {
            // Do something with the exception
        }
    }
