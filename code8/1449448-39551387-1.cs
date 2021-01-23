    int index;
    int num = 0;
    Console.WriteLine("Number of values to sum: ");
    int numOfInput = int.Parse(Console.ReadLine());
    for (index = 1; index <= numOfInput; index++)
    {
        Console.WriteLine("Please give the value of no " + index);
    	num += int.Parse(Console.ReadLine());
    }
    Console.WriteLine("The sum is: " + num);  
