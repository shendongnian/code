     public class Dog
        {
            public virtual void Bark()
            {
                Console.WriteLine("Roff");
            }
        }
        
      public class Wolf:Dog
        {
            public override void Bark()
            {
                Console.WriteLine("Grrr");
            }
        }
