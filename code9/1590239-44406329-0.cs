    using System;
    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            //Valid Dates: "02/02/0002", "02/02/02"        
            //Invalid Dates: "02/02/002", "02/02/00002"        
            string date = "02/02/02";
            bool validDate = isDateTimeFormatValid(date);
            string status = validDate ? "valid" : "invalid";
            Console.WriteLine(date + " is " + status + " date");
            Console.ReadLine();
        }
        private static bool isDateTimeFormatValid(string date)
        {
            DateTime dateResult;
            bool chkYY = false;
            bool chkYYYY = false;
            if (date.Contains("/"))
            {
                chkYY = DateTime.TryParseExact(date, "MM/dd/yy", CultureInfo.InvariantCulture,
                                 DateTimeStyles.None, out dateResult);
                chkYYYY = DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture,
                                 DateTimeStyles.None, out dateResult);
            }
            //Performing OR Operation
            bool result = chkYY | chkYYYY;
            return result;
        }
    }
