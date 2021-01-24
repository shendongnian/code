    public class NonstandardAccount : AccountBase
    {
        // Does work and works perfectly! Username is still accessible
        public string CustomerNumber => Username; 
    }
