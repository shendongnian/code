    //test adding a user and an image.
    var user = new User
    {
        Id = Guid.NewGuid(),
    };
    var image = new Image
    {
        Id = Guid.NewGuid(),
    };
    
    using (var ctx = new Context())
    {
        ctx.Users.Add(user);
        ctx.Images.Add(image);
        ctx.SaveChanges();
    
        //associate them
        user.Images.Add(image);
        image.Users.Add(user);
        ctx.SaveChanges();
    
        //try to add a second image to the user
        var image2 = new Image
        {
            Id = Guid.NewGuid()
        };
    
        try
        {
            user.Images.Add(image2);
            ctx.SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine(ex);
        }
    }
