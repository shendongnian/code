    public static class MailNumberGenerator
    {
        static DateTime CurrentDate = DateTime.Now;
        static int NextNumber = 1;
        public static int GetNext()
        {
            var now = DateTime.Now;
            If(CurrentDate.Date.Equals(now.Date) == false)
            {
                CurrentDate = now;
                NextNumber = 1;
            }
            return NextNumber++;
        }
    } 
