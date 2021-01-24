    var listing = reddit.User.GetPosts(Sort.New, 5, FromTime.Week);
    var posts = listing.GetEnumerator(5, 5, true);
    
    while (posts.MoveNext().Result)
    {
        var post = posts.Current;
        // Do something with post...
    }
