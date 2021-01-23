    abstract class foo
    {
        public abstract int nameOfInt { get; set; }
    }
    
    class bar : foo
    {
        public override int nameOfInt
        {
            get
            {
                throw new NotImplementedException();
            }
    
            set
            {
                throw new NotImplementedException();
            }
        }
    }
