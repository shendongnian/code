    class Program
    {
        static void Main(string[] args)
        {
            Dog fuffy = new Dog("Fuffy", "Armant");
            Console.WriteLine(fuffy.breed); //Prints Fuffy
            Console.WriteLine(fuffy.breed = "Muffy"); //Prints Muffy
            Console.WriteLine(fuffy.breed_readonly = "Muffy"); //World ends in exception
        }
    }
    
    
    class Dog
    {
        public string name {get;set;}
        public string breed {get;set;}
        public string name_readonly {get;}
        public string breed_readonly {get;}
    
        public Dog(string name, string breed)
        {
            this.name = name;
            this.breed = breed;
            this.name_readonly = name;
            this.breed_readonly = breed;
        }
    }
