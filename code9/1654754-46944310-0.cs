	void Main()
	{
		double[] marks = new double[10];
	
		Console.WriteLine("Please enter in 10 marks below: ");
	
		for (int i = 0; i < 10; i++)
		{
			marks[i] = Convert.ToDouble(Console.ReadLine());
		}
	
		Console.WriteLine("You passed {0} subjects.", marks.Where(mark => mark >= 50).Count());
	
		Console.ReadLine();
	}
