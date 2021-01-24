    namespace TimeZoneIds
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                    Console.WriteLine(z.Id);
            }
        }
    }
