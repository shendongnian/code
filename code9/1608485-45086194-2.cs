    int suma = 0;
    int n = 2;
    for (int i = 0; i < n; i++)
    {
        int intNumber;
        double doubleNumber;
        if (int.TryParse(Console.ReadLine(), out intNumber))
        {
            Console.WriteLine("Digite el numero");
            suma += intNumber;
        }
        else if (double.TryParse(Console.ReadLine(), out doubleNumber))
        {
            Console.WriteLine("Digite el otro numero");
            suma += (int)doubleNumber;
        }
        else
        {
            // Tell user input is invalid
        }
    }
    
    Console.WriteLine("Total " + suma);
