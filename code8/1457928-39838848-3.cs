    // True
            Console.WriteLine("2:20 PM".DayMinuteEqual());
            // True
            Console.WriteLine("2:20 P.M.".DayMinuteEqual());
            // False, but we'd expect it due to the omission of the "P.M."
            Console.WriteLine("2:20".DayMinuteEqual());
            // True
            Console.WriteLine("02:20 P.M.".DayMinuteEqual());
            // True
            Console.WriteLine("02:20 PM".DayMinuteEqual());
