    private static void search()
    {
        var key = "your key here";
        if(logBook.ContainsKey(key))
        {
            var post = logBook[key]
            // edit here
            post.Item1 = ....
            post.Item2 = ....
        }
    }
