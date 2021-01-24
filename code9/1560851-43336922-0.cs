     class Program
     {
         static void Main(string[] args)
         {
             var number = 478523698;
             var numberList = new List<int>();
    
             for (var i = 1; i <= number; i *= 10)
             {
                 var currentNumber = number / i % 10;
                 numberList.Add(currentNumber);
             }
    
             Console.WriteLine(numberList.OrderBy(x => x).Skip(1).FirstOrDefault());
    
             Console.Read();
         }
     }
