    public static bool CreateDBF()
    {
       ...
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                ...                
            }
            InsertDataIntoDBF(dbfDirectory + "\\CustomProperties.DBF"); // change 1
            return true;
        }
        catch (Exception ex)
        {
            throw ex; //change2
        }
    }
    public static bool InsertDataIntoDBF(string path)
    {
        try
        {
            ...       
        }
        catch (Exception ex)
        {
            throw ex; //change 3
        }
    }
