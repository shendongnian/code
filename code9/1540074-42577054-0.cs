    class MyClass {
        protected DbContext InternalContext {
            return new DbContext();
        }
        public virtual void MethodOne(DbContext dc = null) {
            if(dc == null)
                dc = InternalContext;
            // do your work
        }
        public virtual void MethodTwo(DbContext dc = nnull) {
            if(dc == null)
                dc = InternalContext;
            // do your work
        }
    }
