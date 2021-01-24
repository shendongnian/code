    public class Class1
    {
        public string NAME { get; set; }
        public Nullable<DateTime> FIRSTDATE { get; set; }
        public Nullable<DateTime> LASTDATE { get; set; }
        public int ElapsedMin { get; set; }
      
        public Class1(DateTime LD, DateTime FD)
        {
            TimeSpan Diff = LD - FD;
            this.ElapsedMin = (int)Diff.TotalMinutes;
        }
    }
