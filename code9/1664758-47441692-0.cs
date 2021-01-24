    public static void Main (string[] args)
		{
			//I am using StreamWriter here only to show//
			//the file can contain more lines//
			StreamWriter a = new StreamWriter ("qasim.txt");
			a.WriteLine ("user1");
			a.WriteLine ("@abc");
			a.WriteLine ("user2");
			a.WriteLine ("abc@");
			a.Close ();
			Console.WriteLine ("Kindly Enter Username:");
			string username = Console.ReadLine();
			Console.WriteLine ("Kindly Enter Password:");
			string pass = Console.ReadLine ();
			StreamReader ab = new StreamReader ("qasim.txt");
			bool userExist = false;
			string line1 = ab.ReadLine();
			string line2 = ab.ReadLine();
			while ((line1 != null) && (line2 != null))
			{
				if ((line1 == username) && (line2 == pass)) 
				{
					userExist = true;
					Console.WriteLine ("Welcome");
					break;
				} 
					
				line1 = ab.ReadLine ();
				line2 = ab.ReadLine ();
			}
			if (userExist == false) 
			{
				Console.WriteLine ("Try Again");
			}
			ab.Close ();
		}
