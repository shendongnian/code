    public class Entry
    {
        private static readonly List<int> hourOfDay;
        static Entry()
        {
            hourOfDay = new List<int>();
            for (int i = 0; i < 25; i++)
            {
                hourOfDay.Add(i);
            }
        }
        public IEnumerable<int> HourOfDaySource => hourOfDay;
    }
