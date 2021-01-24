     class Program {
       // Model: numbers names
       private static string[] s_Numbers = new string[] {
         "Zero", "One", "Two", "Three", "Four",
         "Five", "Six", "Seven", "Eight", "Nine" 
       };
    
       static void Main(string[] args) {
         Console.Write("Write a number between 0-9: ");
    
         // cyclomatic complexity reduction (10 ifs dropped), 
         // readability increasing
         if (int.TryParse(Console.ReadLine(), out var number)) {
           if (number >= 0 && number <= 9)
             Console.Write(s_Numbers[number]);     // number in [0..9] range 
           else
             Console.Write("Out of [0..9] range"); // number out of range 
         else 
           Console.WriteLine("That was an invalid statement."); // not an integer
       }
