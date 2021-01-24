    if (db.ApprovedUsers.Any(u => u.Email == approvedUsers.Email))
    {
        return Content(HttpStatusCode.BadRequest, "Email exists already");
    }
    else
    {
        db.ApprovedUsers.Add(approvedUsers);
    }
       try
       {
          db.SaveChanges();
       }
       catch (DbUpdateException e)
       {
          if (ApprovedUsersExists(approvedUsers.Id))
           {
              return Conflict();
           }
           throw e;
