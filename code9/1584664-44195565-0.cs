    class Program
    {
        public static PersianCalendar PC = new PersianCalendar();
        //I'm using this method for conversion
        public static DateTime GregorianToPersian(DateTime date)
        {
            return new DateTime(PC.ToFourDigitYear(PC.GetYear(date)), PC.GetMonth(date), PC.GetDayOfMonth(date), PC.GetHour(date), PC.GetMinute(date), PC.GetSecond(date), PC);
        }
    
    
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine(GregorianToPersian(new DateTime(2017, 7, 21)));
            System.Diagnostics.Debug.WriteLine(GregorianToPersian(new DateTime(2017, 7, 22)));
        }
    }
