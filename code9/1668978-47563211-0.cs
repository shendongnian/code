	using System;
						
	public class Program
	{
		public static void Main()
		{
			double tal;
			while (true)
			{
				Console.WriteLine("Hej! Skriv in ett tal med decimaler.");           
				string strTal = Console.ReadLine();    
				var ok = double.TryParse(strTal, out tal);
				if (ok) break;
			}
			
			int avrundaren; 
			while (true)
			{
				Console.WriteLine("Tack! Skriv nu in hur många decimaler du vill ha med på ditt tal.");
				string strAvrundaren = Console.ReadLine();
				var ok = int.TryParse(strAvrundaren, out avrundaren);
				if (!ok) continue;
				if (avrundaren < 0) continue;
				break;
			}
	
			Console.WriteLine("Ditt tal är: " + Math.Round(tal,avrundaren)); 
		}
	}
