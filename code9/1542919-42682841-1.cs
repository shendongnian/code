    class MyClass
    {
        private readonly OneTimeAssignable<AnotherClass> mReference = new OneTimeAssignable<AnotherClass>();
        public AnotherClass Reference
        {
            get
            {
                return this.mReference.Value;
            }
            internal set
            {
                this.mReference.Value = value;
            }
        }
    }
