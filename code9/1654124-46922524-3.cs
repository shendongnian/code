    public class Person
    {
        public string Name { get; private set; }
        public Gender Gender { get; private set; }
        public Gender LoveInterestGender { get; private set; }
        public Person(string name, Gender gender, Gender loveInterestGender)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
            Gender = gender;
            LoveInterestGender = loveInterestGender;
        }
    }
