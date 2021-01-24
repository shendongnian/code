       public static void Main(string[] args) {
         float cel = AcceptableCelsius();
         //DONE: please, notice that perfect temperatures is a range, not a set
         if (cel > 74.5 && cel < 75.5) 
           Console.WriteLine("Perfect temperature!");
         else 
           Console.WriteLine("Acceptable temperature.");
         Console.ReadKey();
       } 
