    string[] arr = new string[] {
      "John", "A",
      "Luke", "B",
    }  
    var myDict = Enumerable
      .Range(0, arr.Length / 2)
      .ToDictionary(i => arr[2 * i], 
                    i => arr[2 * i + 1]); 
    Console.WriteLine(string.Join(Environment.NewLine, myDict));
