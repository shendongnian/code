    public class Foo
    {
        public DateTime DateOfBirth => Age?.DateOfBirth ?? DateTime.MinValue;
        public Age Age { get; set; }
    }
