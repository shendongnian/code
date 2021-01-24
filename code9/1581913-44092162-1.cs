    boolean flag = false;
    do {
        if(flag)
            Console.WriteLine("Please enter a valid ID");
        else 
            Console.WriteLine("Please enter your Employee ID: ");
        int ID = Convert.ToInt32(Console.ReadLine());
        employee = controllerclass.findemployee(ID);
        flag = true;
    } while (employee == null) //employee will be null if not found
    Console.WriteLine("The employee exists");
