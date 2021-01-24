    Console.WriteLine(s.Replace("hi"));
    Console.WriteLine(s.Replace("ok"));
    Console.WriteLine(s.Replace("awesome"));
    var words = new string[] {"hi", "you", "look", "awesome"};
    Console.WriteLine(string.Join(" ", words.Select(s.Replace)));
