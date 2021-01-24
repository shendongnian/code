    public ActionResult EditUser(string Name, string Email, string UserName, string Password)
    {
        if(AutorizeLogin(UserName,Password)) //The Login function which returns bool(The function used for login)
        {
            var User = DBContext.Users.SingleOrDefault(x=>x.UserName == UserName);
            User.Name = Name; //Edit the values
            User.Email = Email;
            DBContext.SaveChanges(); //Save changes to database
        }
        else
        {
            //throw error
        }
    }
