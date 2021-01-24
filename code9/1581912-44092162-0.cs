    boolean flag = false;
    do {
        if(flag)
            Console.WriteLine("Please enter a valid ID");
        else 
            Console.WriteLine("Please enter your Employee ID: ");
        int ID = Convert.ToInt32(Console.ReadLine());
        // all the other stuff
        flag = true;
    } while (id == null) 
    Console.WriteLine("The employee exists");
