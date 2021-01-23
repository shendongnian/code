	namespace HelperMethods
	{
		class Program
		{
			static void Main(string[] args)
			{
				var input = GetString();
				DisplayResult(ReverseString(input));
			}
			
			private static string GetString()
			{
				Console.WriteLine("The Name Game");
				Console.Write("What's your first name? ");
				string firstName = Console.ReadLine();
				Console.Write("What's your last name? ");
				string lastName = Console.ReadLine();
				Console.Write("In what city were you born? ");
				string birthPlace = Console.ReadLine();
				string input = firstName + " " + lastName + " " + birthPlace;
				return input;
			}
			private static string ReverseString(string message)
			{
				char[] messageArray = message.ToCharArray();
				Array.Reverse(messageArray);
				return String.Concat(messageArray);
			}
			private static void DisplayResult(string result)
			{
				Console.Write("Results: " + result);
			}
		}
	}
