    class Program
    {
        static void Main()
        {
            Animal dog = new Animal();
            dog.Age = -10;
        }
    }
    
    class Animal
    {
        private int age;
        private string color;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Age is wrong");
                }
                else
                {
                    age = value;
    				Console.WriteLine(age);
                }
             }
        }
    }
