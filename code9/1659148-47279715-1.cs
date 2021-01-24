    public class ExecutionObject
    {
        public string ExecutionTime { get; set; }
        public DateTime ExecutionTimeDateTime {
            get
            {
                return DateTime.ParseExact(this.ExecutionTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            set
            {
                this.ExecutionTime = value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
