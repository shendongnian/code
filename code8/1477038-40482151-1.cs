    public void UpdateItem(Item item)
    {
       var currentUser = //get the user from the database or session
       if(currentUser.Roles.Any(r=>r.Permissions.Any(p=>p.Id == (int)Permissions.Update))
       {
         // do the logic
       }
       else
       {
         // show access denied
       }
    }
