    string prvnicislo = String.Empty;
    bool isEntryWrong = true;
    do
    {
        Console.Write("Enter data: ");
        prvnicislo = Console.ReadLine();
        int num;
        if(int.TryParse(prvnicislo, out num))
        {
            isEntryWrong = false;
        }
        else
        {
            Console.WriteLine("'{0}' is not int, try it again:", prvnicislo);
        }
    } while (isEntryWrong);
    Console.WriteLine("Hi")
