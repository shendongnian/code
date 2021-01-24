     public static class DateTimeHelper
        {
            public static void AlwaysChooseMonday(this DateTimePicker dtp, DateTime value)
            {
                var days = DayOfWeek.Monday - dtp.Value.DayOfWeek;
    
                if (dtp.Value.DayOfWeek != DayOfWeek.Monday)
                {
                    dtp.Value = new DateTime(dtp.Value.Year, dtp.Value.Month, dtp.Value.Day + days);
                }
            }
        }
