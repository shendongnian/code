    var input = new int[] { 1, 5, 3, 7, 2, 10, 15, 9, 6 };
    var sorted = input
        .OrderBy(z => z)
        .ToList();
    var zippedInOrder = sorted.Take(input.Length / 2)
                            .Zip(
                                Enumerable.Reverse(sorted).Take(input.Length / 2),
                                (a, b) => new int[] { a, b });
    var inOrder = zippedInOrder.SelectMany(z => z);
    if (input.Length % 2 == 1)
    {
        // Add the 'middle' element (sort order wise) 
        inOrder = inOrder.Concat(new List<int> { sorted[input.Length / 2] });
    }
    var finalInOrder = inOrder.ToList();
    // To test
    Console.WriteLine(string.Join(",", finalInOrder));
