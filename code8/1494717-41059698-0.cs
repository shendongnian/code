    static void AdminMenu()
    {
    char innerchoice;
    Console.WriteLine("Press [1] to Add new student.");
    Console.WriteLine("Press [2] to Add new course.");
    Console.WriteLine("Press [3] to Enter course prerequisite.");
    Console.WriteLine("Press [4] to View List of all students in a specific course.");
    Console.WriteLine("Press [5] to View List of Finished courses.");
    Console.WriteLine("Press [6] to View List of courses in progress.");
    Console.WriteLine("Press [7] to edit all course data.");
    innerchoice = char.Parse(Console.ReadLine());
    switch (innerchoice)
    {
        case '1':    
            break;
        case '2':    
            break;
        case '3':      
            break;
        case '4':       
            break;
        case '5':    
            break;
        case '6':       
            break;
        case '7':    
            break;
        default:
            AdminMenu();
            break;// add break in default
    }
    }
