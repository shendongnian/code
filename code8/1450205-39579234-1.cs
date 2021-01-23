	Console.WriteLine("What is your name");
	string name = Console.ReadLine();
	Console.WriteLine("What is your hourly rate\n1=6.53\n2=7.48\n3=8.89");
	int hourlyRate = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("How many hours do you work?\n1=35\n2=38\n43");
	int noOfHour = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("What is you National Insurance no.?\n1=JLS302\n2=KM8215\nPQ7316");
	int niNumber = Convert.ToInt32(Console.ReadLine());
    //ADDED this here:
	double rate = 0.00;
	switch (hourlyRate)
	{
		case 1: {
			rate = 6.53;
			break;
		}
		case 2: {
			rate = 7.48;
			
			break;
		}
		case 3: {
			rate = 8.89;
			break;
		}		
		
	}
	Console.WriteLine("This is the rate: " + rate);
