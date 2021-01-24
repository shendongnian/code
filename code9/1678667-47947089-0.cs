    Class A
    {
        string name = "a"; 
        public virtual void Rename(){//rename name to aaa}
    }
    Class B:A
    {
        public override void Rename(){//rename name to bbb}
        public B() { name = "b"; }
    }
