    int choice;
    if(!Int32.TryParse(Console.ReadLine(), out choice))
       Console.WriteLine("You should enter a integer number");
    else
    {
        switch(choice)
        {
            case 1:
                // action for choice == 1
                break;
            case 2:
                // action for choice == 2
                break;
            default:
                // action for any other integer number
                break;
       }
    }
    
