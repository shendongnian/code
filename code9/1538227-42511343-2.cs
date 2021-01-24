       using System.Linq;
       ...
       public static void Main(string[] args) {
         var result = File
           .ReadLines(@"InputData.txt")
           .Select(line => line
              .Split(new char[] { ',', ';'}, StringSplitOptions.RemoveEmptyEntries)
              .Select(item => {
                 int v;
                 bool parsed = int.TryParse(item, out v);
                 return new {
                   value = v,
                   isParsed = parsed,
                 }; 
               })
              .Where(item => item.isParsed)
              .Sum(item => item.value));
         int lineIndex = 0;
         long grandTotal = 0;
         foreach (var sum in result) {
           Console.WriteLine( 
             $"The sum of the numbers entered at line {lineIndex + 1} is: {sum}");  
           lineIndex += 1;
           grandTotal += sum;
         }  
         Console.Write($"Grand total is {grandTotal}");  
       }
