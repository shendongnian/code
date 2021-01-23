    BlockingCollection<MyClass> bCollection = new BlockingCollection<MyClass>(boundedCapacity: 2);
    bCollection.Add(new MyClass{ Field1 = "Test" });
    bCollection.Add(new MyClass{ Field1 = "Test2" };
     
    var item = bCollection.Take();
    item = bCollection.Take();
     
    if (bCollection.TryTake(out item, TimeSpan.FromSeconds(1)))
    {
        Console.WriteLine(item);
    }
    else
    {
        Console.WriteLine("No item removed");
    }
