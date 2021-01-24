    public static class Extensions
    {
        public static string GetCustomFormatString(this DateTime input, 
            bool excludeTimeIfZero = true)
        {
            return input.TimeOfDay == TimeSpan.Zero && excludeTimeIfZero
                ? input.ToString("MM/dd/yyyy")
                : input.ToString("MM/dd/yyyy hh:mm:ss");
        }
    }
