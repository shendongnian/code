    catch (SqlException ex)
    {
        try
        {
            //Call Error Management DB Connection and add content to the table
            using (SqlConnection connection = new SqlConnection(_errorManagementConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[dbo].[InsertDataErrors]", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InputParam", InputParam);
                cmd.Parameters.AddWithValue("@Content", Content);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        catch
        {
            // Add any desired handling.
        }
        throw new DataException(ex.Message, ex);
    }
