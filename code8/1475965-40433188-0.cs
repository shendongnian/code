        int age = 12;
        if ((age >= 0) && (age <= 12))
        {
            Console.WriteLine("You are young");
        }
        else if ((age >= 13) && (age <= 17))
        {
            Console.WriteLine("You're a teen");
        }
        else if ((age >= 18) && (age <= 50))
        {
            Console.WriteLine("You're an adult");
        }
        else if ((age >= 51) && (age <= 120))
        {
            Console.WriteLine("You're Elderly");
        }else
        {
            Console.Beep();
        }
