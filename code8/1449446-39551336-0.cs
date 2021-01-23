    private void SumNumbers()
    {
        int index;
        int num = 0;
        for (index = 0; index < numOfInput; index++)
        {
            Console.WriteLine("Please give the value of no " + index);
            num += int.Parse(Console.ReadLine());
            Console.WriteLine("The sum so far is : "+num.ToString("N0")+". Enter another number to continue summation.");
        }
        Console.WriteLine("Maximum input received. Total is: "+num.ToString("N0")+".");
        Console.ReadLine();
    }
