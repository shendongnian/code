        string query = "The University of Hong Kong";
        var results = GoogleSearch.Search(query);
        foreach (Result result in results)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Title: {0}", result.Title);
            Console.WriteLine("Link: {0}", result.Link);
        }
        Console.ReadKey();
 
    
