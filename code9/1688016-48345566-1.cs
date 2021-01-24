    using (var db = new AccountContext())
    {
         db.UserPermissions.Add(permission);
         var saveChangesResult = db.SaveChanges();
         if (saveChangesResult == 0)
         {
             AppUserManager.Delete(user);
             return BadRequest("User permission could not be saved");
         }
    }  
