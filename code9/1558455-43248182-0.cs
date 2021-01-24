    //Declarations
    SqlCommand CMD;
    SqlCommand CMDUPDATE;
    SqlDataReader Reader;
    
    private void Save(string EmplID, double MRate, double HRate, double DRate)
    {
         CMD = new SqlCommand("SELECT * FROM tblEmpl WITH (NOLOCK) WHERE ACTIVE = 1", dbConn.connection);
         Reader = CMD.ExecuteReader();
         while (Reader.Read())
         {
              CMDUPDATE = new SqlCommand("UPDATE tblEmpl SET MRate = " + MRate + ", HRate = " + HRate + ", DRate = " + DRate + " WHERE EmplID = '" + EmplID + "'", dbConn.connection);
              CMDUPDATE.ExecuteNonQuery();
         }
    }
