	double length = 0, width = 0;
	const double feet = 3.75;
	//questions
	Console.Title = "Double Glazing Window Calculator";
	Console.WriteLine("Double Glazing Calculator\n");
	while (true)
	{
		Console.Write("Enter the height of the of the window in meteres ");
		double.TryParse(Console.ReadLine(), out length);
		Console.Write("Enter the width of the of the window in meteres ");
		double.TryParse(Console.ReadLine(), out width);
		if (length < 1 || width < 1)
		{
			Console.WriteLine("Enter a valid input (between 1 and 2^53)");
		}
		else
		{
			break;
		}
	}
	//maths
	var totalarea = length * width * 2;
	var totallength = (length * 2 + width * 2) * feet;
	Console.WriteLine("The total area of the glass required in m^2 (to 2 decinmal places) is {0} ", totalarea.ToString("0.##"));
	Console.WriteLine("the total length of the wood required in feet (to 2 decimal places) is {0}", totallength.ToString("0.##"));
