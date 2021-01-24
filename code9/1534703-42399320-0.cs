    var indexes =
         File.ReadAllLines(indexFileName)
        .Where(s => !String.IsNullOrEmpty(s))
        .Select(x => x.Split(','))
        //  Turn the array into something self-documenting
        .Select(a => new { Word = a[0], Path = a[1] })
        .GroupBy(o => o.Word)
        .ToDictionary(o => o.Key, x => o.FirstOrDefault()?.Path)
        ;
