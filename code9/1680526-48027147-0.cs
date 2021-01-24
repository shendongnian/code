    using (var jr = new ChoJSONReader<Filter>("sample10.json")
        )
    {
        foreach (var x in jr)
        {
            Console.WriteLine($"FilterName: {x.filterName}");
            Console.WriteLine($"FilterformattedValue: {x.filterformattedValue}");
            Console.WriteLine($"filterValue : {x.filterValue}");
            Console.WriteLine($"View: {x.view}");
        }
    }
