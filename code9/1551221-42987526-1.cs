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
        catch (Exception)
        {
            throw; //change2
        }
    }
    public static bool InsertDataIntoDBF(string path)
    {
        try
        {
            ...       
        }
        catch (Exception)
        {
            throw; //change 3
        }
    }
