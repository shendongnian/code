    var user = new User(){
       Name = "UserName",
       Person  = new Person(){
           FirstName="FirstName",
           LastName ="LastName",
           ...
       }
    };
    
    db.Users.Add(user);
    db.SaveChanges();
