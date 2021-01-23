    public class Pet
    {
        private static readonly Random _rand = new Random();
  
        public Pet()
        {
            type = ToType(_rand.Next(10));
            // ...
        }
    }
