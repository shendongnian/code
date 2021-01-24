    public class Person
    {
        public virtual string Id { get; set; }
        // ...
    }
    public class Student : Person
    {
        public override string Id { get; set; }
        // ...
    }
    // ...
