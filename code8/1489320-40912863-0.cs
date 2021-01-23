    List<String> data;
    {
        var rows = Enumerable.Range(1, 10);
        var sets = Enumerable.Range(1, 6);
        var itemsPerSet = Enumerable.Range(1, 2);
        data = rows.Select(rowIndex =>
            String.Join(Environment.NewLine,
                String.Join(",", sets.Select(setIndex =>
                    String.Join(",", itemsPerSet.Select(itemIndex =>
                        $"Value{rowIndex}-{setIndex}-{itemIndex}")))))).ToList();
        foreach (var row in data)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine(new String('-', 20));
    }
