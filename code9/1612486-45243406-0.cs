    public class Dog
    {
        public int Age { get; set; }
    }
    
    public class Program
    {
        public static void Main()
        {
            var dog1 = new Dog { Age: 3 };
            var dog2 = new Dog { Age: 5 };
        }
    }
