      internal class MappingData
     {
      public int TrooxID {get; set} // Here i declare only TrooxID  of Troox for sample can declare all of the fields  in Troox as  one by one
      public DateTime TranferDate{ get; set; }
      public string UserName{ get; set; }
      public string UserName1{ get; set; }
       
     }
     
    using (var context = new MyDBContext())
     {
     var TrooxUserId= new SqlParameter("@TrooxUserId","51");
     string sqlQuery = @"SELECT Troox.TrooxID, Transfers.TranferDate, Users.UserName, Users_1.UserName as UserName1
                       FROM((Troox LEFT JOIN Transfers ON Troox.TrooxID = Transfers.TrooxID)
                       LEFT JOIN Users ON Transfers.SenderID = Users.UserId) 
                       LEFT JOIN Users AS Users_1 ON Transfers.ReceiverID = Users_1.UserId where Troox.UserId =@TrooxUserId";
     var Results = db.Database.SqlQuery<MappingData>(sqlQuery,TrooxUserId).ToList();
     }
