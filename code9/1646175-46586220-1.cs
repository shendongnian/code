    Console.WriteLine("CHINESE");
    Console.Write("Type in the number of the dish you want: ");
    int id = Convert.ToInt32(Console.ReadLine());
    if (menu.ContainsKey(id))
    {
        Console.WriteLine($"{menu[id]} is added to your list.");
    }
    else
    {
        Console.WriteLine($"{id} is not available.");
    }
    Console.ReadKey();
