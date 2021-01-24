       private static float[] inputArray() {
         List<float> list = new List<float>();
         while (true) {
           string textEntered = Console.ReadLine();
           
           if (textEntered.ToUpperInvariant().Contains("STOP"))
             return list.ToArray();
           if (float.TryParse(textEntered, out var item))
             list.Add(item);
           else
             Console.WriteLine($"\"{textEntered}\" is not a floating point value, ignored");
         }
       } 
       ...
       float[] array = inputArray();
       //TODO: you may want to check here if array is not empty
       if (array.Length == 0)
         Console.WriteLIne("The array is empty");
       else {
         Console.WriteLine($"[{string.Join(", ", array)}]"); 
         Console.WriteLine($"  Max   = {array.Max()}"); 
         Console.WriteLine($"  Min   = {array.Min()}"); 
         Console.WriteLine($"  Total = {array.Sum()}");  
       }
