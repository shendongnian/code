    public static void ComputeMarksSummary(IEnumerable<string> subjectNames)
    {
         var marks = new List<int>();
         
         foreach (var subject in sujectNames)
         {
             marks.Add(GetUserInput(string.Format("Enter your {0} marks: ", subject)));
         }
         
         var total = marks.Sum();
         Console.WriteLine("Your total marks are {0} out of 1000", total);
         Console.WriteLine("Your percentage is: {0}%", total/10.0); //note the 10.0 to force double division, not integer division where 44/10 would be 4 not 4.4
         Console.WriteLine("Note: the percentage has been rounded off. Please share this program with other classmates, also I am open to suggestions for creating more helpful programs.");
         Console.ReadLine();
    }
