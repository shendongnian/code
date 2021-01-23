    public abstract class Building
    {
        public Person Person { Get; Set; }
    
        public Building Building { Get; Set; }
    }
    
    public class House : Building
    {
        // Other House properties
    }
    
    public class Garage : Building
    {
        // Other Garage properties
    }
