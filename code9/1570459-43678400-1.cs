    int x = 1;
        
        switch(x)
        {
            case 1: // Enters Here cause x = 1
                Console.WriteLine("test"); //prints
                switch(x) // x still = 1
                {
                    case 1: //enters here cause x = 1
                    Console.WriteLine("works"); //prints
                    break;
                }
                break;
            default:
                Console.WriteLine("doesnt work");
                break;
        }
