      [WebMethod]
      public static bool DoesDataExist(string proj, string surv )
      {
          SqlCommand commandrepeat1 = new SqlCommand("Select * from table where project="+proj+" and Survey="+surv+" ");
          commandrepeat1.Connection = objconnection;
          objconnection.Close();
          objconnection.Open();
          SqlDataReader drmax1;
          drmax1 = commandrepeat1.ExecuteReader();
          drmax1.Read();
          if (drmax1.HasRows)
          {
              objconnection.Close();
              return true;
          }
       
          objconnection.Close();
          return false;
    }
