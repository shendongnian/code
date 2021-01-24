        Console.WriteLine("Please state your marks........");
        string uservalue = Console.ReadLine();
        int x = Convert.ToInt32(uservalue);
        if (x >=60)
        {
            Console.WriteLine("Passed Grade B");
        }
        else if (x >=50)
        {            
            Console.WriteLine("You Passed");            
        }
        
        Console.ReadLine();
