    int Size = -1;
    while (Size == -1) {
        Console.WriteLine("Pick a coffee Size");
        Console.WriteLine("1: Small");
        Console.WriteLine("2: Medium");
        Console.WriteLine("3: Large");
        Size = int.Parse(Console.ReadLine());
        switch (Size)
        {
            case 1:
                price += 1.20;
                break;
            case 2:
                price += 1.70;
                break;
            case 3:
                price += 2.10;
                break;
            default:
                Size = -1;
                Console.WriteLine("This option does not exist");
                break;
        }
    }
