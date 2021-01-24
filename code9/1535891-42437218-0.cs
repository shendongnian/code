            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            List<DayOfWeek> daylist = new List<DayOfWeek>();
            int i = (int)dfi.FirstDayOfWeek;
            int addDay = 3;
            while (i <= ((int)dfi.FirstDayOfWeek + addDay) % 7)
            {
                daylist.Add((DayOfWeek)i);
                i++;
            }
