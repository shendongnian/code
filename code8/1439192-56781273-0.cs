    public class Example: Registry
    {
        public Example()
        {
            Schedule(() =>
            {
                DayOfWeek[] available = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
                if (DateTime.Now.DayOfWeek.IsOn(available) && (DateTime.Now.Hour == 8 && DateTime.Now.Minute == 0))//etc
                {
                    //code
                }
            }).WithName("Example").ToRunEvery(0).Hours().At(0).Between(8, 0, 17, 0);
        }
    }
