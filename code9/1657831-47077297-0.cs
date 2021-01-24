    class Program
    {
        static void Main (string[] args)
        {
            var person = Person.FromName ();
        }
    }
    public class Person
    {
        private Person (string name, string surname) { }
        public static Person FromName (string name = "John") => new Person (name, "Smith");
        public static Person FromFullName (string name = "John", string surname = "Smith") => new Person (name, surname);
    }
