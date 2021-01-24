    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var breed = new Dog();
            }
        }
    
    
        public struct Dog
        {
            public string Breed { get; set; }
    
            public Dog(string breedName) //: this()
            {
                Breed = breedName;
            }
        }
    }
