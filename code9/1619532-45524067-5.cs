    public class AlarmModel {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Content { get; set; }
        public DateTime TimeCreate { get; set; }
        public DateTime AlarmTime { get; set; }
        public bool? AlarmStatus { get; set; } //<-- needs to be nullable for 3 states
    }
