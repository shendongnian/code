    public class Question
    {
    	public int Id { get; set; }
    
    	public string Text { get; set; }
    	
    	public IDictionary<string, string> Answers { get; set; }
    	
    	public string CorrectAnswer { get; set; }
    }
    
    public static class Program
    {
    	public static IEnumerable<Question> _questions = new []
    	{
    		new Question
    		{
    			Id = 1,
    			Text = "What position does the ramp contol knob need to be in?",
    			Answers = new Dictionary<string, string>
    			{,
    				{ "A", "3N" },
    				{ "B", "1" },
    				{ "C", "6N" },
    				{ "D", "A or C" }
    			},
    			CorrectAnswer = "D"
    		}
    	};
    
    	public static IDictionary<int, string> _answers = new Dictionary<int, string>();
    	
    	public static void Main()
    	{
    		Console.WriteLine("Chad Mitchell - ENGR 115 - USAF HC130J Power On Quiz\n");
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nWelcome to the HC-130J Power-On Quiz " + firstName + ".\n");
    		Console.WriteLine("Using the keyboard, please submit answers by using the \'ENTER\' key.\n");
            Console.WriteLine("Please submit answers in CAPITAL letter form only.\n");
            Console.WriteLine("Ready to begin " + firstName + "? Hit the \'ENTER\' key now...");
            Console.ReadLine();
            Console.Clear();
    		
    		foreach(var question in _questions)
    		{
    			Console.WriteLine(question.Text);
    			Console.WriteLine();
    			foreach(var answer in question.Answers)
    			{
    				Console.WriteLine(string.Format("{0}. {1}", answer.Key, answer.Value));
    			}
    			Console.WriteLine("What is your answer " + firstName + "?");
    			var response = Console.ReadLine();
    			while(!question.Answers.ContainsKey(response))
    			{
    				Console.WriteLine("\nError - Not a Valid Input - Please Enter Valid Input");
    				response = Console.ReadLine();
    			}
    			if(response == question.CorrectAnswer)
    			{
    				Console.WriteLine("\nThat is correct!");
    			}
    			else
    			{
    				Console.WriteLine("\nSorry, that is incorrect.");
    			}
    			_answers[question.Id] = response;
    		}
    		
    		// do whatever you want when the test is over
    	}
    }
