    double length = 0, 
           width = 0, 
           totalarea, 
           totallength;
    const double feet = 3.75;
    //questions
    Console.Title = "Double Glazing Window Calculator";
    Console.WriteLine("Double Glazing Calculator\n");
    bool InputFalse = false;
    while(true){
        GetAndVerifyInput(out length, "Enter the length of the of the window in meteres: ");
        GetAndVerifyInput(out width, "Enter the width of the of the window in meteres: ");
        //maths
        totalarea = length * width * 2;
        totallength = (length * 2 + width * 2) * feet;
        Console.WriteLine();
        Console.WriteLine("The total area of the glass required in m^2 (to 2 decimal places) is {0} ", totalarea.ToString("0.##"));
        Console.WriteLine("the total length of the wood required in feet (to 2 decimal places) is {0}", totallength.ToString("0.##"));
        Console.WriteLine();
        Console.WriteLine();
    }
    
    private void GetAndVerifyInput(out double result, string instruction) {
        while (true)
        {
            Console.Write(instruction);
            if (double.TryParse(Console.ReadLine(), out result) && 
                result > 0 && 
                result < Math.Pow(2,53) + 1)
                return;
            Console.WriteLine("Enter a valid input (between 1 and 2^53)");
         }
    }
