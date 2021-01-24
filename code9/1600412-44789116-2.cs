        private void saveTableToDataBase()
        {
        	string tableName = dbTableName;
        	bool tableExist = false;
        
        	// check if table exist in sql server
        
        	if (IsTableExistInDb(tableName) == true) {
        		// table exist do something...
        
        	} else {
        		// create table
        		string createTableQuery = "CREATE TABLE " & "." & tableName & "(" & _
                    "ID int  IDENTITY (1, 1) NOT NULL PRIMARY KEY, " & _
                    "Col1 int, " & _
                    "Col2 decimal(5,4), " & _
                    "Col3 int, " & _
                    "Col4 decimal(5,4), " & _
                    "Col5 int " & _
                    ")"
                    // create table in database
                    Insert(createTableQuery);
        	}        
        }
        
            
        public static Boolean IsTableExistInDb(string tableName)
        {
        
            Object result = ExecuteScalarWithAnonimusType("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = " + "'" + tableName + "'", Connection);
        
            if (result != null && byte.Parse(result.ToString()) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }
        
        public static object ExecuteScalarWithAnonimusType(string query)
    {
        Cmd = new SqlCommand(query, Con);
        try
        {
            return Cmd.ExecuteScalar();
        }
    
        catch (Exception ex)
        {
            return null;
        }
        finally
        {
    
            if (Con.State != ConnectionState.Closed)
                Con.Close(); Con.Close();
        }
    }
    
        public static Boolean Insert(string query)
        {
            try
            {
                DB.ExecuteDataSet(CommandType.Text, query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
