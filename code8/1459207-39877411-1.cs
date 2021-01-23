        for (int i = 0; i <= test.Length; i++)
        {
            Console.WriteLine("Please enter test " + i);
            test[i] = Convert.ToInt32(Console.ReadLine()); //putting your value
            if (test[i]<=90)//check your value
            { 
                Console.WriteLine("note is A");
            }
            //... same here
            
           Console.ReadKey();
        }
