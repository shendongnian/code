        IEnumerable<string> s = new List<string>() { "1", "2", "3" };
        var i = s.Select(url =>
            {
                Console.WriteLine(url);
                url = string.Format("--{0}--",url);
                return url;
            }
        ).ToList();
        Console.WriteLine("done with selector");
        foreach (string f in i)
        {
            Console.WriteLine("f is {0}", f);
        }
