    // Create a list of consecutive integers and display it
    var numbers = Enumerable.Range(1, 30).ToList();
    Console.WriteLine("Original list:");
    Console.WriteLine(string.Join(", ", numbers));
    // Shuffle the list and display it again
    var rnd = new Random();
    numbers = numbers.OrderBy(n => rnd.NextDouble()).ToList();
    Console.WriteLine("\nShuffled list:");
    Console.WriteLine(string.Join(", ", numbers));
