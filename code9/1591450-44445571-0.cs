    public interface IMyClass
    {
        int Code {get;}
    }
    public class myClass1 : IMyClass
    {
        public int Code { get; set; }
        public List<myItem> Items { get; set; }
    }
    public class myClass2 : IMyClass
    {
        public int Code { get; set; }
        public List<myItem> Items { get; set; }
    }
    public class myItem
    {
        //Initialization scope
        private readonly int _parentCode;
        public myItem(IMyClass parent)
        {
           _parentCode = parent.Code;
        }
        
        //...
        //Execution scope
        private void MyMethod()
        {
            int ParentClass_CodeProperty = _parentCode;
        }
    }
