    public abstract class BadMessage 
    {    
        public int GetID() 
        { 
            throw new InvalidOperationException
               ("This method is not needed for BadMessage and should not be called"); 
        }
        public bool GetLocalized() { ... }
        public string GetMetadata() { ... }
    }
