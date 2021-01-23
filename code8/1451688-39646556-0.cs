    public class SomeClass
    {
        public virtual int SomeMethod()
        {
          return SomeOtherMethod() / 2;
        }
    
        protected virtual SomeOtherMethod()
        {
            return [some crazy maths]
        }
    }
