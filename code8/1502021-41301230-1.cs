    public static void ComputeMarksSummary()
    {
         var marks = new List<int>();
         
         marks.Add(GetUserInput("Enter your Urdu marks: "));
         marks.Add(GetUserInput("Enter your Maths marks: : "));
         marks.Add(GetUserInput("Enter your English Literature marks: "));
         marks.Add(GetUserInput("Enter your Biology marks: "));
         marks.Add(GetUserInput("Enter your Chemistry marks: "));
         marks.Add(GetUserInput("Enter your Islamiat marks: "));
         marks.Add(GetUserInput("Enter your Computer marks: "));
         marks.Add(GetUserInput("Enter your English language marks: "));
         marks.Add(GetUserInput("Enter your Pakistan studies marks: "));
         var total = marks.Sum();
         Console.WriteLine("Your total marks are {0} out of 1000", total);
         Console.WriteLine("Your percentage is: {0}%", total/10.0); //note the 10.0 to force double division, not integer division where 44/10 would be 4 not 4.4
         Console.WriteLine("Note: the percentage has been rounded off. Please share this program with other classmates, also I am open to suggestions for creating more helpful programs.");
         Console.ReadLine();
    }
    private static int GetUserInput(string message)
    {
         int mark;
         while (true)
         {
              Console.WriteLine(message);
              var input = Console.ReadLine();
              if (!ValidateUserInput(input, out mark))
              {
                   Console.WriteLine("Invalid input, please try again.");
              }
              else
              {
                   return mark;
              }
         }
    }
    private static bool ValidateUserInput(string message, out int input)
    { //left as an excerice. Hint: look into int.TryParse(...); }
