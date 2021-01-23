	Console.WriteLine("Please enter your red value: ");
	byte redValue = Convert.ToByte(Console.ReadLine());
	
	Console.WriteLine("Please enter your green value: ");
	byte greenValue = Convert.ToByte(Console.ReadLine());
	
	Console.WriteLine("Please enter your blue value: ");
	byte blueValue = Convert.ToByte(Console.ReadLine());
	Color color = new Color(redValue, greenValue, blueValue, 255);
