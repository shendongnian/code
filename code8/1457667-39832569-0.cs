    public static void Main()
	{
		Random rnd = new Random();
		var li = new List<int> {1,2,5,3,6,8};
		var timesToPrint = 10;
		
		var goldenNumber = 3;
		
		 // this is actually 55% chance, because we generate a number form 0 to 100 and if it is  > than 45 we print it... so 55% chance
		var chanceToPrintGoldenNumber = 45;
		
		
		// Print as many times as there are numbers on the list
		
		Console.WriteLine("Printing as many times as there are elements on the list");
		
		foreach(var number in li)
		{		
			var goldenNumberChance = rnd.Next(0,100);
			
			if (goldenNumberChance > chanceToPrintGoldenNumber) // 55% chance to print goldenNumber
			{
				Console.WriteLine(goldenNumber);			
			}
			else
			{			
				var i = rnd.Next(0,li.Count);
				Console.WriteLine(li[i]);			
			}
		}
		
		Console.WriteLine("****************** END ***************************");
		
		// Print as many times as the value of your "timesToPrint".
		
		Console.WriteLine("Printing as many times as the value on timesToPrint ");
		
		for(var i=0; i< timesToPrint; i++)
		{
			var goldenNumberChance = rnd.Next(0,100);
			
			if (goldenNumberChance > chanceToPrintGoldenNumber) // 55% chance to print goldenNumber
			{
				Console.WriteLine(goldenNumber);			
			}
			else
			{			
				var n = rnd.Next(0,li.Count);
				Console.WriteLine(li[n]);			
			}
			
		}
		
	}
	
