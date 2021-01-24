    using (SqlConnection connection = new SqlConnection(conString))
    {
        try
        {
            //your switch case statement
        }
        catch (InvalidOperationException)
        {
           
        }
        catch (SqlException)
        {
           
        }
    }
