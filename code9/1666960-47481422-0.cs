	class firstClass
	{
		public static void Main (string[] args)
		{
				int choice = 0;
			while (choice != 1 && choice != 2)
				{
				
				Console.WriteLine ("Press 1 for choice 1 or 2 for choice for choice 2");
				choice = Convert.ToInt32 (Console.ReadLine ());
				if (choice == 1) {
					crap.secondClass.myMethod();
				}
				if (choice == 2) {
				}
			}
		}
	}
	public class secondClass{
		public static void myMethod()
		{
	
			Console.WriteLine("You chose option 1");
		}
	}
}
