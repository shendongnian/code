    case 1:
        Console.Write("Lägg till föremål i ryggsäcken: ");
        while(true)
        {
            string lineEntered = Console.ReadLine();
    
            //Now here comes the break operator
            if(lineEntered == "stopImDone"){
            break;
            mylist.Add(lineEntered);
        }
        
        break;
    }
