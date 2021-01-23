            int Input = 32453; //Amount of seconds 
            TimeSpan ts = new TimeSpan(0, 0, Input); //3 constructor arguments are (Hours, Minutes, Seconds)
            if (ts.Days > 0)
            {
                Console.WriteLine(ts.Days + " Day(s)");
            }
            else if (ts.Hours > 0)
            {
                Console.WriteLine(ts.Hours + " Hour(s)");
            }
            else if (ts.Minutes > 0)
            {
                Console.WriteLine(ts.Minutes + " Minute(s)");
            }
            else
            {
                Console.WriteLine(ts.Seconds + " Second(s)");
            }
            Console.Read();
