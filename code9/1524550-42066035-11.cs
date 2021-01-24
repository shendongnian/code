    public class Cat : IAnimal
    {
        public string Name =>"Kitty";
       
        public void MakeSound()
        {
            Console.WriteLine("Meeeee-ow!");
        }
    }
        
        public class Dog : IAnimal
        {
            public string Name => "Lucy";
        
            public void MakeSound()
            {
                Console.WriteLine("Wolf Wolf!");
            }
        }
