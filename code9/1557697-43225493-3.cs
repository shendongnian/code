    if (model.Id == "")
     {
      //Add new user code
     }
    else
     {
      var context = myUserStore.Context as ApplicationDbContext;
      var Team = context.Users.Find(model.Id);
      //change the field value what ever you want to update
      context.Users.Attach(Team);
      context.Entry(Team).State = EntityState.Modified;
      context.Configuration.ValidateOnSaveEnabled = false;
      await context.SaveChangesAsync();
      return Ok("Updated");
     }
   
