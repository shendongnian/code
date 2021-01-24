    var input = new int[] { 1, 5, 3, 7, 2, 10, 15, 9 };
    IEnumerable<int> sorted = input
        .OrderBy(z => z)
        .ToList();
    var zippedInOrder = sorted.Take(input.Length / 2)
                            .Zip(
                                sorted.Reverse().Take(input.Length / 2),
                                (a, b) => new int[] { a, b });
    var inOrder = zippedInOrder.SelectMany(z => z);
    if (input.Length % 2 == 1)
    {
        // Add the 'middle' element (sort order wise) 
        inOrder = inOrder.Concat(sorted.ElementAt(input.Length / 2));
    }
    var finalInOrder = inOrder.ToList();
