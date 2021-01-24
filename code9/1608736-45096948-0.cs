    using System;
    
    public class Program
    {
        public static void Main()
        {
            string Logintime = "07-10-2017 09:28:00";
            string Logoutime = "07-10-2017 17:16:22 ";
            DateTime Logintimedt = Convert.ToDateTime(Logintime);
            DateTime Logoutimedt = Convert.ToDateTime(Logoutime);
            DateTime today = new DateTime(Logintimedt.Year, Logintimedt.Month, Logintimedt.Day, 9, 20, 00);
            TimeSpan diff = (Logoutimedt - Logintimedt);
            TimeSpan delay = Logintimedt - today;
    
            Console.WriteLine(diff);
            Console.WriteLine(delay);
        }
    }
