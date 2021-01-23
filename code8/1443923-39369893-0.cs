    OleDbConnection con = new OleDbConnection(constr);
    while ((s = sr.ReadLine()) != null)
    {
      // Do the job here
    }
    con.Close();
