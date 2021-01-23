    int num;
	string prvnicislo;
    prvnicislo = Console.ReadLine();
    while (true)
    {
        if (int.TryParse(prvnicislo, out num))
        {
            Convert.ToInt32(prvnicislo);
			break;
        }
        else
        {
            Console.WriteLine("'{0}' is not int, try it again:", prvnicislo);
            prvnicislo = Console.ReadLine();
        }
    }
    Console.WriteLine("Hi");
