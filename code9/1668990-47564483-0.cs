	class Uno
	{
		public int Grade { get; set; }
	
		public void Evaluate()
		{
			if (this.Grade >= 45)
			{
				if ((this.Grade % 5) > 2)
				{
					this.Grade += 5 - (this.Grade % 5);
				}
			}
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			Uno a = new Uno();
			Console.WriteLine("Enter grades. Enter one per line. Enter a blank line to stop.");
	
			string input = Console.ReadLine();
			while (input != "")
			{
				int grade = int.Parse(input);
				if (grade > 100 || grade < 0)
				{
					Console.WriteLine("Invalid input. Try again.");
					input = Console.ReadLine();
					continue;
				}
				a.Grade = grade;
				a.Evaluate();
				Console.WriteLine(a.Grade);
				input = Console.ReadLine();
			}
		}
	}
