    abstract class Choix
    {
        public abstract bool Load();
        public abstract bool Lauch();
        public abstract bool Result();
    }
    
    class AddTenant : Choix
    {
        public override bool Load()
        {
            // Load ...
            return true;
        }
    
        public override bool Lauch()
        {
            // Lauch ...
            return true;
        }
    
        public override bool Result()
        {
            // Result ...
            return true;
        }
    }
