     private static List<string> Search(string[] studentName, int[] studentGrade, int grade) {
       List<string> result = new List<string>();
       // Let's use good old for loop instead of Linq
       for (int i = 0; i < studentGrade.Length; ++i)
         if (studentGrade[i] == grade)
           result.Add(studentName[i]);
       return result; 
     }
     public static void ShowResults(int userInput) {
       Console.WriteLine();
       Console.WriteLine("The following students have that grade: ");
       Console.WriteLine();
       List<string> list = Search(studentGrade, studentName, userInput); 
       if (list.Count <= 0)
         Console.WriteLine("{0} is NOT in array", userInput);
       else
         Console.WriteLine("{0} {1}", string.Join(", ", list), userInput);
    }
