    var foo = new YourClass();
    foo.Comments = new List<Comment>();
    foo.Comments.Add("bar"); // note that it works *like* a string 
    // the following is the equivalent, but just looks like a usual class initializer
    foo.Comments.Add(new Comment("bar"));
