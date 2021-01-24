    public class Place {
        public interface Athena { }
    }
    public class Sparta : Place
    {
        public void printTypeOfThis()
        {
            Console.WriteLine (this.GetType().Name);
        }
        
        public void printTypeOfSparta()
        {
            Console.WriteLine (typeof(Sparta));
        }
    
        public void printTypeOfAthena()
        {
            Console.WriteLine (typeof(Athena));
        }
    }
