    public interface IDateTimeInt32Converter
    {
        DateTime Int32ToDateTime(int value);
        int Int32ToDateTime(DateTime date);
    }
    public class YearMonthDayConverter : IDateTimeInt32Converter
    {
        // etc
    }
    // Ditto for MonthDayYearConverter and DayMonthYearConverter
