           Console.WriteLine("What year was your car made? [MUST BE IN YEAR FORMAT]");
            caryearchk = Console.ReadLine();
            int caryearchkint;
            if (int.TryParse(caryearchk,caryearchkint) // Can't figure out a way to return a bool through .GetType()
            {
                Console.Write("Error. you MUST submit this in an integer form. The application will now close.");
                Console.ReadLine();
            }
            else
            {              
            }
            caryear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the drivetrain? [ FWD /// RWD /// AWD /// 4WD ]");
            cartrain = Console.ReadLine();
        }
        Car car = new Car(carmake, 
