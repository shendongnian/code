    class A : IMyParam
    {
        public virtual string MyParam { get; set; }
    }
    class B : A
    {
        public override string MyParam
        {
            get { return base.MyParam != null ? base.MyParam.Substring(1) : null; }
        }
    }
