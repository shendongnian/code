    public class Parent
    {
        public int age;
        public static Parent operator +(Parent a, Parent b)
        {
            return new Parent(a, b);
        }
        protected Parent(Parent a, Parent b)
        {
          this.age = a.age + b.age;
        }
    }
    public class Child : Parent
    {
        public static Child operator +(Child a, Child b)
        {
            return new Child(a, b);
        }
        protected Child(Child a, Child b) : base(a,b)
        {
            // anything you need to do for adding children on top of the parent code.
        }
    }
