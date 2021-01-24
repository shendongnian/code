    boolean flag = false;
    do {
        if(flag)
            Console.WriteLine("Please enter a valid ID");
        else 
            Console.WriteLine("Please enter your Employee ID: ");
        try{
             int ID = Convert.ToInt32(Console.ReadLine());
        } catch (FormatException e){
            Console.WriteLine("Please enter an integer");
            flag = false;
            continue;
        } 
        employee = controllerclass.findemployee(ID);
        flag = true;
    } while (employee == null) //employee will be null if not found
    Console.WriteLine("The employee exists");
