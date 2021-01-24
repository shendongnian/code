        Console.WriteLine("Please enter a positive integer: ");
        var args = Console.ReadLine();
        if (int.TryParse(args, out int num))
        {
            if (num < 0)
                Console.WriteLine('Must enter a positive integer!');
            for (var i = num; i >= 10; i-- )
            {
               //this only runs if the integer entered is >= 10 
               if (num > 10)
               {
                 Console.WriteLine(i);
               }
            }
        }
        else
        {
            Console.WriteLine("A non-integer was entered!");
        }
      
