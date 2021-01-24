    var items = new List<object> { 7, 28, -1, true, "chair" };
    int sum = 0;
    
    foreach(var item in items)
    {
        Console.WriteLine(item);
        if (item.GetType() == typeof(int))
            sum += (int)item;
    }
    
    // Now display the sum
    Console.WriteLine($"The sum is: {sum}");
