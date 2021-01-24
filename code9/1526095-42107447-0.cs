    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
    public static List<Employees> GetEmployee() 
    {
      List<Employees> emp = new List<Employees>();
      var query = "SELECT * FROM employee";
      MyConn = new OdbcConnection(MyConnection);
      myCommand = new OdbcCommand(query, MyConn);
      MyConn.Open();
      OdbcDataReader reader = myCommand.ExecuteReader();
      while (reader.Read()) 
      {
         Employees empl = new Employees();
         empl.Id = Convert.ToInt32(reader["ID"]);
         empl.image = reader["picture"].ToString();
         empl.lastName = reader["last_name"].ToString();
         empl.firstName = reader["first_name"].ToString();
         empl.jobTitle = reader["job_title"].ToString();
         empl.StartDate = Convert.ToDateTime(reader["start_date"]);
         empl.EndDate = Convert.ToDateTime(reader["end_date"]);
         emp.Add(empl);
       }
    
       MyConn.Close();
       return emp;
    }
