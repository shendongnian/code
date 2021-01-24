    This is how it worked for me:
    
    private static int WeightIFeMale()
        {
                Console.WriteLine("How Much Do You Weigh?", Environment.NewLine);
        } 
     int femaleWeight;
        
                if (!int.TryParse(Console.ReadLine(), out femaleWeight)) //I deleted the else statement.
        {
        Console.Write("What the **** is {0} It has to be a number numb nuts, lets try that again!", Environment.NewLine);
            Console.Write(Environment.NewLine);
            WeightIFeMale();
        }
        else if 
            (femaleWeight >= 0   && femaleWeight <= 80)
        {
            Console.WriteLine("Damn, how much crack are you smoking?", Environment.NewLine);
        }
        else if
            (femaleWeight >= 81 && femaleWeight <= 110)
        {
            Console.WriteLine("What the ****, are you a midget *****?", Environment.NewLine);
    
        }        
        else if 
            (femaleWeight >= 111 && femaleWeight <= 140)
        {
            Console.WriteLine("Holy ***, I have some protein bar coupons you can have!", Environment.NewLine);
    
        }
        else if 
            (femaleWeight >= 141 && femaleWeight <= 160)
        {
            Console.WriteLine("Bro you need to hit the Gym, ASAP!", Environment.NewLine);
    
        }
        else if 
            (femaleWeight >= 161 && femaleWeight <= 200)
        {
            Console.WriteLine("Really!!!, can I hit the Gym with you?", Environment.NewLine);
    
        }
        else if 
            (femaleWeight >= 201 && femaleWeight <= 240)
        {
            Console.WriteLine("Do you Have a small ****, Steroids are a mother @#$%^&&", Environment.NewLine);
    
        }
        else if 
            (femaleWeight >= 241 && femaleWeight <= 999)
        {
            Console.WriteLine("My condolences!", Environment.NewLine);
        }
        else if 
            (femaleWeight >= 1000)
        {
            Console.WriteLine("There is absolutely no way that you weigh {0} lbs, so stop ******* around!", femaleWeight, Environment.NewLine);
        }
       
        
