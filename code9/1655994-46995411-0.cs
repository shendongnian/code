    public class Exercise
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Set> SetList { get; set; } 
        public byte RestTime { get; set; }
        [JsonIgnore]
        public virtual Workout Workout { get; set; }
        public int WorkoutId { get; set; }
    }
    public class Set
    {
        public int Id { get; set; }
        public byte Rep { get; set; }
        public int Weight { get; set; }
        public int NumberOfDS { get; set; }
        public double PercentDrop { get; set; }
        [JsonIgnore]
        public virtual Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }
    }
