    using System; 
    using System.Globalization; 
    public class Program
    {
    	public static void Main()
    	{
    		var dt = DateTime.Now;
    		
    		DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            var yourFormat = string.Format(
                "{0:yy}{1:00}.{2:d}"
                , dt
                , cal.GetWeekOfYear(dt,CalendarWeekRule.FirstFourDayWeek,DayOfWeek.Sunday)
                , dt.DayOfWeek )
    		
    		Console.WriteLine(yourFormat);
    	} 
    }
