    void PrintMenu()
    {
        Console.WriteLine("Press [1] to Add new student.");
        Console.WriteLine("Press [2] to Add new course.");
        Console.WriteLine("Press [3] to Enter course prerequisite.");
        Console.WriteLine("Press [4] to View List of all students in a specific course.");
        Console.WriteLine("Press [5] to View List of Finished courses.");
        Console.WriteLine("Press [6] to View List of courses in progress.");
        Console.WriteLine("Press [7] to edit all course data.");
    }
    static void AdminMenu()
    {
        bool run = true;
        while(run)
        {
            PrintMenu();
            char innerchoice = char.Parse(Console.ReadLine());
    
            switch (innerchoice)
            {
                case '1':
                    run = false;
                    break;
                case '2':    
                    run = false;
                    break;
                case '3':      
                    run = false;
                    break;
                case '4':       
                    run = false;
                    break;
                case '5':    
                    run = false;
                    break;
                case '6':       
                    run = false;
                    break;
                case '7':    
                    run = false;
                    break;
            }
        }
    }
