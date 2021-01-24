    public interface IDateTimeInt32Converter
    {
        DateTime Int32ToDateTime(int value);
        Int32ToDateTime(DateTime date);
    }
    public class YearMonthDayConverter : IDateTimeInt32Converter
    {
        // etc
    }
    // Ditto for MonthDayYearConverter and DayMonthYearConverter
