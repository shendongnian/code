    var User = GetUserById(Id);  // returns a disconnected user
    User.Language = UserModel.Language;
    // Attach back to context and tell EF it is updated
    DBContext.Users.Attach(User);
    DBContext.Entity(User).State=EntityState.Modified;
    DBContext.SaveChanges();
