    using (var entites = = new ADMIN_DB_Entities())
    {
       try
       {
          entities.Base64Payload.Add(newBase64PayLoadEntry);
          entities.SaveChanges();
       }
       catch (Exception ex)
       {
          ConsoleAppLog.WriteLog(ex.Message);
       }
    }
