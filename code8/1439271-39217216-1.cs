    class ParentClass
    {
        public int mode = 0;
        public ChildClass child = null;
        public ParentClass()
        {
            child = new ChildClass(this);
        }
    }
    class ChildClass 
    {
        public readonly ParentClass parent = null;
        public ChildClass (ParentClass parent)
        {
            this.parent = parent;
        }
        public int MethodThatReadsParentMode()
        {
            int mode = parent.mode;
            return mode;
        }
    }
