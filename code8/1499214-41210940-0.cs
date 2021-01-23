        private void button1_Click(object sender, EventArgs e)
        {
            List<DateTime> Thursdays = DaysOfMonth(2016, 12, DayOfWeek.Thursday);
            foreach(DateTime dt in Thursdays)
            {
                Console.WriteLine(dt.ToString());
            }   
        }
        public static List<DateTime> DaysOfMonth(int year, int month, DayOfWeek day)
        {
            List<DateTime> dates = new List<DateTime>();
            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                DateTime dt = new DateTime(year, month, i);
                if (dt.DayOfWeek == day)
                {
                    dates.Add(dt);
                }
            }
            return dates;
        }
