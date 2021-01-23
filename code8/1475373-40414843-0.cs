    Console.WriteLine("Queue before adding new element");
    foreach (string msg in msgs)
    {
        Console.WriteLine(msg);
    }
    
    Console.WriteLine("Enter Something to the queue");
    msgs.Enqueue(Console.ReadLine());
    
    Console.WriteLine("Queue before adding new element");
    foreach (string msg in msgs)
    {
        Console.WriteLine(msg);
    }
