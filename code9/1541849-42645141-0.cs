     Console.WriteLine("Please enter the first rate");
            var NGNRate = Convert.ToDoouble(Console.ReadLine());
    
            Console.WriteLine("Please enter the  Master rate");
            var TM_USD_ZAR = Convert.ToDouble(Console.ReadLine());
    
            Console.WriteLine(NGNRate / TM_USD_ZAR);
