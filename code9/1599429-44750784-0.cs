    public class MyBaseClass<T>
    {
        public virtual T MyMethod()
        {
            return default(T);
        }
    }
    public class MyIntClass : MyBaseClass<int>
    {
        public override int MyMethod()
        {
            return 1;
        }
    }
    public class MyListClass : MyBaseClass<List<int>>
    {
        public override List<int> MyMethod()
        {
            return new List<int>();
        }
    }
