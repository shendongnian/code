     public int getContactSetCount(string searchPhrase)
     {
        int ret = 0;
        try
        {
            string query = string.Empty;
            if (!string.IsNullOrWhiteSpace(searchPhrase))
            {
                // ********* Assuming your db table is also called ContactSet **********************
                query = @"SELECT COUNT(*) FROM ContactSet s WHERE s.FirstName LIKE '%' + @p0 + '%' OR s.LastName LIKE '%' + @p0 + '%')";
                ret = db.Database.SqlQuery<int>(query, new System.Data.SqlClient.SqlParameter(parameterName: "@p0", value: searchPhrase)).FirstOrDefault();
            }
            else
            {
                ret = db.ContactSet.Count();
            }
        }
        catch (Exception)
        {
             throw;
        }
        return ret;
    }
