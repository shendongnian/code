    class Dog
    {
        public string Name {get;} // read-only property (can be set in constructor)
        public string Breed {get;}
    
        public Dog(string name, string breed)
        {
            this.Name = name;
            this.Breed = breed;
        }   
    }
