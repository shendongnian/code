    using System.Linq;
    var data = new int[] { 52, 05, 08, 66, 02, 10 };
	var sortingDictionary = data
	    .Select((value, index) => new { value, index })
        .ToDictionary(pair => pair.index, pair => pair.value);
		
	var sorted = sortingDictionary.OrderBy(kvp => kvp.Value);
		
	for (var newIndex = 0; newIndex < sorted.Count(); newIndex ++) {
	    var item = sorted.ElementAt(newIndex);
        Console.WriteLine(
            $"New index: {newIndex}, old index: {item.Key}, value: {item.Value}"
        );
	}
