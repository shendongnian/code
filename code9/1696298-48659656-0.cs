    using (myEntities myContext = new myEntities())
    {   
        // Create a query string
        string myQuery = @"SELECT    DISTINCT t.name AS 'TableName' "+
                            "FROM        sys.columns c "+
                            "JOIN        sys.tables  t   ON c.object_id = t.object_id "+
                            "WHERE       c.name LIKE '%@CustomField%' "+
                            "ORDER BY    TableName"; 
                            
        // Create a query
        //If you return a primitive type you can use ObjectQuery<string>
        ObjectQuery<DbDataRecord> tableQuery = new ObjectQuery<DbDataRecord>(myQuery, myContext);
        
        // Add parameters.
        tableQuery.Parameters.Add(new ObjectParameter("CustomField", "FOOBAR"));
        
        // Go through the Result 
        foreach (DbDataRecord rec in tableQuery)
        {
            Console.WriteLine("TableName\t [{0}]", rec[0]);
        }
    }
