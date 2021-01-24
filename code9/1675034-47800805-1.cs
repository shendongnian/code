    public class Animal
    {
        private string name;
    
        public string Name
        {
            get { return name;  }
            //set { name = value; } just comment it out
        }
    
        public Animal(string name)
        {
            this.name = name;
        }
    
        public virtual void WhoAmI()
        {
            Console.WriteLine("I am an animal !");
        }
    
        public virtual void Describe()
        {
            Console.WriteLine("My name is {0}.", name);
        }
    
        public void Rename(string NewName)
        {
            name = NewName;
        }
    }
