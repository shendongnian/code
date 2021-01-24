    public class ExecutionObject
    {
        [Column("ColExecutionTime")]
        public string ExecutionTime { get; set; }
        [NotMapped]
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
