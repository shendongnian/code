    int num = 0;
    int sum = 0;
    Console.Write("Enter a number:");
    num = Convert.ToInt32(Console.ReadLine());
    for (int i = 1; i <= num; i++)
    {
     Console.WriteLine(i);
     sum += i;               
    }
    Console.WriteLine("Sum is"+sum);
