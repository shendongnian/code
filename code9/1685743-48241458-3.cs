     static void Main(string[] args)
     {
         var guid = new Guid("bdc39e63-5947-4704-9e12-ec66c8773742");
         Console.WriteLine(guid);
         var numbers = FindNumbersFromGuid(guid, 16, 8);
         Console.WriteLine("Numbers: ");
         foreach (var elem in numbers)
         {
             Console.WriteLine(elem);
         }
         Console.ReadKey();
     }
     private static int[] FindNumbersFromGuid(Guid input,
         int maxNumber, int numberCount)
     {
         if (numberCount > maxNumber / 2) throw new ArgumentException("Choosing too many numbers.");
         var seed = input.GetHashCode();
         var random = new Random(seed);
         var chosenSoFar = new HashSet<int>();
         return Enumerable.Range(0, numberCount)
             .Select(e =>
             {
                 var ret = random.Next(0, maxNumber);
                 while (chosenSoFar.Contains(ret))
                 {
                     ret = random.Next(0, maxNumber);
                 }
                 chosenSoFar.Add(ret);
                 return ret;
             }).ToArray();
     }
