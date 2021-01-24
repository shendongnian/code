    public class StreamReaderWithMaxTime : StreamReader
    {
        public TimeSpan MaxTime { get; set; } = new TimeSpan(0, 1, 0);
        public DateTime? Start { get; set; }
        public override int ReadBlock(char[] buffer, int index, int count)
        {
            if (Start == null)
                Start = DateTime.Now;
            if (Start.Value.Add(MaxTime) < DateTime.Now)
                throw new Exception("Timeout! Max readtime reached!");
            return base.ReadBlock(buffer, index, count);
        }
    }
