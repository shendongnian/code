    var items = new List<object>
    {
        "first",
        "second",
        new List<string> { "listFirst", "listSecond" },
        new [] { "arrayFirst", "arraySecond" },
        "third"
    };
    foreach (var item in items)
    {
        if (item is ICollection)
        {
            var innerItems = item as IEnumerable;
            Console.WriteLine("Collection type encountered:");
            foreach (var innerItem in innerItems)
            {
                Console.WriteLine($" - {innerItem}");
            }
        }
        else
        {
            Console.WriteLine(item.ToString());
        }
    }
