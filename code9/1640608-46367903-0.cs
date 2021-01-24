    class Dog
    {
        public string Name { get; set; }
    }
    class Cat
    {
        public string Type { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog { Name = "My Dog" };
            string strDog = JsonConvert.SerializeObject(dog);
            Cat cat = new Cat { Type = "My Cat" };
            string strCat = JsonConvert.SerializeObject(cat);
            var dog2 = JsonConvert.DeserializeObject<Dog>(strDog);
            var cat2 = JsonConvert.DeserializeObject<Cat>(strCat);
            Console.WriteLine(cat2.Type); 
            Console.WriteLine(dog2.Name);          
        }
    }
