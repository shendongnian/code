    public class MyClass
    {
        public MyClass(IDataAccessLayer dal)
        {
            this.Dal = dal;
        }
        public IDataAccessLayer Dal { get; set; } 
    }
