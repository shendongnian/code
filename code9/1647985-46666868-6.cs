       static int ReadGrade(string title) {
         while (true) {
           Console.WriteLine(title);
           int result = 0;
           if (int.TryParse(Console.ReadLine(), out result) &&
               result >= 0 &&
               result <= 100)
             return result;
           Console.WriteLine("Please, try again"); 
         }
       }
       static void Main(string[] args) {
         do {
           int medeltal = (ReadGrade("math: ") +
                           ReadGrade("gym: ") + 
                           ReadGrade("classroom: ")) / 3;
           Console.WriteLine(GradeMe(medeltal));
           Console.WriteLine("Next grade (Y/N)?");
         }
         while (string.Equals("Y", 
                               Console.ReadLine().Trim(), 
                               StringComparison.OrdinalIgnoreCase))
       }
