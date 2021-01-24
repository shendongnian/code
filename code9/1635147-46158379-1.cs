     var st = "0,35mA";  
     var li = Regex.Matches(st, @"([,\d]+)([a-zA-z]+)").Cast<Match>().ToList();  
  
     foreach (var t in li)
     {
         Console.WriteLine($"Group 1 {t.Groups[1]}")
         Console.WriteLine($"Group 2 {t.Groups[2]}");
     }
