    class UserName
    {
        public string firstName {get; set;}
        public string lastName {get; set;
    }
    var result = db.Users
        .Where(user => user.email == useremail)
        .Select(user => new UserName()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
        });
