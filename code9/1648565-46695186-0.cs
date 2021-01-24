    int intResourceID = 0;
    
    //this will try to convert but you won't see exeptions when failed
    Int32.TryParse(hfResourceID.Value, out intResourceID);
    
    //checks if there is a value in the hiddenfield, but can throws yellow screen if not convertible
    if (!string.IsNullOrEmpty(hfResourceID.Value))
    {
        intResourceID = Convert.ToInt32(hfResourceID.Value);
    }
    
    //catch an error when the value is not convertible, can be wrapped with !string.IsNullOrEmpty(hfResourceID.Value)
    try
    {
        intResourceID = Convert.ToInt32(hfResourceID.Value);
    }
    catch (Exception ex)
    {
        //handle the error, can be seen with ex.Message
    }
    
    //if the hidden value is still 0 (for whatever reason) you might not want to execute the query
    //so the next part will return and stop executing the rest of the code
    if (intResourceID == 0)
    {
        return;
    }
    
    //update the database, using 'using' will ensure proper closure of the connection and disposing of any objects
    using (SqlConnection connection = new SqlConnection("myConnectionString"))
    using (SqlCommand command = new SqlCommand("ResourceCreateOrUpdate", connection))
    {
        //set the command type and add the parameters
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@ResourceID", SqlDbType.Int).Value = intResourceID;
    
        try
        {
            //open the database connection and execute the command
            connection.Open();
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //there was an error opening the database connection or with the command, can be viewed with ex.Message
        }
    }
