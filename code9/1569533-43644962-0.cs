    static void Main() {
            TimeZoneInfo easternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            TimeZone timeZone = TimeZone.CurrentTimeZone;
            DateTime oneAm = TimeZoneInfo.ConvertTime(new DateTime(2017, 03, 12, 01, 00, 00), easternStandardTime);
            DateTime fourAm = TimeZoneInfo.ConvertTime(new DateTime(2017, 03, 12, 04, 00, 00), easternStandardTime);
            DaylightTime time = timeZone.GetDaylightChanges(fourAm.Year);
            TimeSpan difference = ((fourAm - time.Delta) - oneAm);
            Console.WriteLine(oneAm);
            Console.WriteLine(fourAm);
            Console.WriteLine(TimeZoneInfo.Local.IsDaylightSavingTime(oneAm));
            Console.WriteLine(TimeZoneInfo.Local.IsDaylightSavingTime(fourAm));
            Console.WriteLine(difference);
            Console.ReadLine();
        }
