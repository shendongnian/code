    class BaseClass
    {
        public int BaseProp { get; set; }
    }
    class SubClass : BaseClass, ISubClass
    {
        public int ChildProp { get; set; }
    }
    interface ISubClass
    {
        int ChildProp { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            var obj = new SubClass() as BaseClass;
            // obj IS SubClass type, but we are only going to use properties and methods
            // available to ANY BaseClass
            obj.BaseProp = 1;  // this is fine
            obj.ChildProp = 2;  // this doesn't work (BaseClass does not contain a definition for ChildProp)
            (obj as SubClass).ChildProp = 2;  // this works
        }
    }
