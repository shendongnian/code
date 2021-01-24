    public class ClassStudents
    {
        public string Name { get; set; }
        public int Value { get; set; }
        // Override the equality operation to check for text value only
        public override bool Equals(object obj)
        {
            if (obj is ClassStudents other) // use pattern matching
            {
                return Name.Equals(other.Name);
            }
            return false;
        }
    }
