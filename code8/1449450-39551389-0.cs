              do
            {
                int farenheight = getTemp();
                celsius = FahrToCels(fahrenheit);
                if (celsius < 73)
                {
                    Console.WriteLine(celsius);
                    Console.WriteLine("It's too cold, raise the temperature.");
                }
           }
     public int getTemp(){
         return int.Parse(Console.ReadLine());
     }
