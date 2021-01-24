    class A
    {
        public virtual string MyParam { get; }
    }
    
    class B : A // note here that B derives from A, not the other way round
    {
        public override string MyParam 
        { 
            get { return base.MyParam != null ? base.MyParam.Substring(1) : null; },
            set { ... }
        }
    }
