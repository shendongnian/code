        private void saveTableToDataBase()
        {
        	string tableName = dbTableName;    
    
        	// check if table exist in sql server db
        	if (IsTableExistInDb(tableName) == true) {
        		// table exist do something...
        
        	} else {
        		// create table, replace with your column names and data types
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
        
            Object result = ExecuteScalarWithAnonimusType("SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = " + "'" + tableName + "'", Con);
        
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
    
        public static bool Insert(string command)
        {
        
        	try {
        		con = new SqlConnection(System_Vars.SqlClientConnString);
        		con.Open();
        		cmd = new SqlCommand(command, con);
        		return cmd.ExecuteNonQuery();
        
        	} catch (Exception ex) {
 
        		return false;
				
        	} finally {
        		con.Close();
        	}
        }
        
