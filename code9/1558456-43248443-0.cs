    //Declarations
    SqlCommand CMD;
    SqlDataReader Reader;
    
    private void Save(string EmplID, double MRate, double HRate, double DRate)
    {
         CMD = new SqlCommand("SELECT a,b FROM tblEmpl WITH (NOLOCK) WHERE ACTIVE = 1", dbConn.connection);
         Reader = CMD.ExecuteReader();
         while (Reader.Read())
         {
           //// TODO : Populate a List of model with all the records
              
         }
        //// Foreach records update it
        
        Foreach(var item in <List of models>)
        {
              CMD = new SqlCommand("UPDATE tblEmpl SET MRate = " + item.MRate + ", HRate = " + item.HRate + ", DRate = " + item.DRate + " WHERE EmplID = '" + item.EmplID + "'", dbConn.connection);
              CMD.ExecuteNonQuery();
        }
    }
