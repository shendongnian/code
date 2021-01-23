    class A 
    {
        protected string _Name;
        protected virtual void f() { 
            _Name = typeof(A).Name; //or nameof(A)
        }
    }
