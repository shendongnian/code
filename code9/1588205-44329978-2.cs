    public class Card
    {
        // ...
        
        public Card GetDeepCopy()
        {
            Card deepCopy = new Card(); 
            deepCopy.Property1 = this.Property1;
            // ...
            return deepCopy;
        }
    }
