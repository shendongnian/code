     // long: we don't want overflow, e.g. 2000000000, 1000000000 
     long sum = 0;
     while (true) {
       // Trim() - let's be nice and allow user put leading/trailing spaces
       string input = Console.ReadLine().Trim();
       if (string.Equals("x", input, StringComparison.OrdinalIgnoreCase))
         break;
       if (int.TryParse(input, out var item))
         sum += item;
       else {
         //TODO: Incorrect input, neither integer nor "x" (e.g. "abracadabra")  
       }   
     }
     Console.WriteLine(sum);
     Console.Read(); 
