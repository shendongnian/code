    while (true)
    {
    	Console.WriteLine("Please enter the student's name:");
    	studentName = Console.ReadLine();
    	//Prompt the user for the student's score
    	Console.WriteLine("Please enter the student's score between 0 and 100:");
    	if (!(double.TryParse(Console.ReadLine(), out grade)))
    	{
    		Console.WriteLine("Invalid entry, scores entered must be numeric. Please try again");
            break;
    	}
    	else if (grade >= 90)
    	{
    		Console.WriteLine("{0} has a score of {1} which is an A.", studentName, grade);
    	}
    	else if (grade < 90 && grade >= 80)
    	{
    		Console.WriteLine("{0} has a score of {1} which is a B.", studentName, grade);
    	}
    	else if (grade < 80 && grade >= 70)
    	{
    		Console.WriteLine("{0} has a score of {1} which is a C.", studentName, grade);
    	}
    	else if (grade < 70 && grade >= 60)
    	{
    		Console.WriteLine("{0} has a score of {1} which is a D.", studentName, grade);
    	}
    	else
    	{
    		Console.WriteLine("{0} has a score of {1} which is an F.", studentName, grade);
    	}
    }
