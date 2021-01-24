    // If the class is public then it's visible to other assemblies.
    // If the class isn't public then other assemblies can't see public
    // members because they can't see the class itself.
    public class Foo
    {
        // Accessible to classes inside the project.
        internal string SomeField; 
        // Accessible to classes outside the project.
        public string SomeProperty { get; set; }
    }
