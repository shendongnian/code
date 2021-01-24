    public abstract class Activity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public readonly string ActivityType; // consider to use enum
        public Activity(string activityType)
        {
            ActivityType = activityType;
        }
    }
