    public class TaskDetail
    {
        public int Id { get; set; }
        [JsonIgnore ]
        public IBehavior Behavior { get; set; }
    }
