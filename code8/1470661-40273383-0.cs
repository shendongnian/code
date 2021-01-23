    class Animal
    {
        public virtual void talk() { 
            Console.WriteLine("woohhoo");
        }
    }
    
    class dog : Animal
    {
      public override void talk()
      {
         Console.WriteLine("woof");
      }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal();
    
            a.talk();
    
            dog d = new dog();
    
            d.talk();
            
            // this part is key, when you have a dog as an animal, when you 
            // call talk it will use the overriden method
            Animal da = d;
            da.talk();
        }
    }
