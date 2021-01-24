    var foo = new YourClass();
    foo.Comments = new List<Comment>();
    foo.Comments.Add("");
    foo.Comments.Add("");
    // note that it works *like* a string 
    // the following is the equivalent
    foo.Comments.Add(new Comment(""));
