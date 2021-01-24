    int nthWeek = 49;
		
		int result = (nthWeek % 3);
		
		switch(result)
		{
			case 0:
				Console.WriteLine("Worker is working on Friday");
			break;
			
			case 1:
				Console.WriteLine("Worker is working on Monday");
			break;
			
			case 2:
				Console.WriteLine("Worker is working on Wednesday");
			break;
			
			default:
				Console.WriteLine("Worker is working on other day");
			break;
		}
