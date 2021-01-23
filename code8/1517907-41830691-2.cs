    public class TimeSimulation
    {
        public int Second { get; set; }
        public int Minute { get; set; }
        public int Hour { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    } // I think this bracket was missing..
    static DateTime gameTime;
    public static void TimeSettings()
    {
        TimeSimulation startTime = new TimeSimulation();
        startTime.Second = 1;
        startTime.Minute = 1;
        startTime.Hour = 1;
        startTime.Day = 1;
        startTime.Month = 1;
        startTime.Year = 2000;
        gameTime = new DateTime(startTime.Year, startTime.Month, startTime.Day, startTime.Hour, startTime.Minute, startTime.Second);
    }
    public static void ShowTime()
    {
        //DateTime gameTime = new DateTime(startTime.Year, startTime.Month, 
        if(gameTime != null)
        {
            startTime.Day, startTime.Hour, startTime.Minute, startTime.Second);
            Console.WriteLine(gameTime);
        }
    }
