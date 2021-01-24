    public enum Gender
    {
        Female,
        Male
    }
    public struct User
    {
        public int Age { get; }
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime Time { get; }
        public User(DateTime time, Gender gender, string name, int age)
        {
            Time = time;
            Gender = gender;
            Name = name;
            Age = age;
        }
    }
