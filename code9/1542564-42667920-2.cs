    var entity = new CustomModel
    {
        Id = Guid.NewGuid(),
        ObjectExample = "string",
        ObjectExample2 = "secString",
        UserId = User.Identity.GetUserId() //Identity Lib will provide this method for you
    };
    using(MyDbContext context = new MyDbContext())
    {
        context.CustomModel.Add(entity); 
    }
