    for (int i = 0; i < numCust; i++)
    {
        Console.WriteLine("What is this customer's order?");
        lunchCombo = Convert.ToInt32(Console.ReadLine());
        switch (lunchCombo)
        {
            case 1:
                total = total + 4.25M;
                break;
            case 2:
                total = total + 5.75M;
                break;
            case 3:
                total = total + 5.25M;
                break;
            case 4:
                total = total + 3.75M;
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
