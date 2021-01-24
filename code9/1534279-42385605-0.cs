    public class FileData
    {
        public FileData(IEnumerable<string> hours, IEnumerable<string> dates)
        {
            Hours = hours;
            Dates = dates;
        }
    
        public IEnumerable<string> Hours { get; }
        public IEnumerable<string> Dates { get; }
    }
