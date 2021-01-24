    using (var web = site.AllWebs["wts"])
    {
        Console.WriteLine(web.Title);
        var lists = web.Lists;
        // some code that uses web
    }
