    public abstract class BadMessage 
    {    
        public override int GetID() 
        { 
            throw new InvalidOperationException
               ("This method is not needed for BadMessage and should not be called"); 
        }
        public override bool GetLocalized() { ... }
        public override string GetMetadata() { ... }
    }
