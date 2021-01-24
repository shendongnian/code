    int[] intArray = { 5, 12, 0, 67, 75, 3, 27, 1, 98};
    int[] searchValues = { 0, 25, 99, 12, 3 };
    var indices = searchValues.Select(i => new { Value = i, Index = Array.IndexOf(intArray, i) });
    var foundValues = indices.Where(x => x.Index >= 0).ToArray();
    var unfoundValues = indices.Where(x => x.Index < 0).ToArray();
    foreach (var val in foundValues)
        Console.WriteLine("The Value {0} Has been found in index {1} of intarray ", val.Value, val.Index);
    foreach (var val in unfoundValues)
        Console.WriteLine("The Value {0} was Not found in intarray ", val.Value);
