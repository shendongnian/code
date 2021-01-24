    public class ItemDto { }
    public class Item { }
    var transform = new TransformBlock<ItemDto, Item>(dto => new Item(),
        // all cores can be used for processing
        new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = Environment.ProcessorCount });
    var dtoList = new List<ItemDto>();
    foreach (var item in dtoList)
    {
        transform.Post(item);
    }
