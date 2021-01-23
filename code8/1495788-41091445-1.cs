    var inputItems = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });//List<int> is just example, input sequence can be any IEnumerable<T>
    var processedItems = inputItems
        .AsParallel()//Allow parallel processing of items
        .AsOrdered()//Force items in output enumeration to be in the same order as in input
        .WithMergeOptions(ParallelMergeOptions.NotBuffered)//Allows enumeration of processed items as soon as possible (before all items are processed) at the cost of slightly lower performace
        .Select(item =>
            {
                //Do some processing of item
                Console.WriteLine("Processing item " + item);
                return item;//return either input item itself, or processed item (e.g. item.ToString())
            });
    //You can use processed enumeration just like any other enumeration (send it to the customer, enumerate it yourself using foreach, etc.), items will be in the same order as in input enumeration.
    foreach (var processedItem in processedItems)
    {
        //Do whatever you want with processed item
        Console.WriteLine("Enumerating item " + processedItem);
    }
