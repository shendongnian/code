    public static DateTime Int32ToDateTime(int value)
    {
        int year = value % 10000;
        int day = (value / 10000) % 100;
        int month = value / 1000000;
        // Specify whatever kind is appropriate; it's unclear from the question.
        return new DateTime(year, month, day);
    }
    public static int DateTimeToInt32(DateTime date) =>
        date.Year + (date.Day * 10000) + (date.Month * 1000000);
