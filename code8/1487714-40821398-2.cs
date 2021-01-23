    int sum = 0;
    foreach(var item in array)
    { 
        sum += item;
    }
    var average = sum * 1.0 / array.Length;
    List<int> aboveAverageItems = new List<int>();
    foreach(var item in array)
    {
        if(item > average)
        {
            //If you need to know how many items and not which then use a counter and increase
            aboveAverageItems.Add(item);
        }
    }
    Console.WriteLine($"{string.Join(", " aboveAverageItems)} integers are above average.");
