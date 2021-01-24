    public class Program
    {
        public static void Main()
        {
            // This is a local and NOT initialized
            int number;
            var person = new Person();
            Console.WriteLine(person.age); // This will work
            Console.WriteLine(number); // This will not work
            Console.Read();
        }
    }
    
    public class Person
    {
        // This is a field so it will be initialized to the default of int which is zero
        public int age;
    }
