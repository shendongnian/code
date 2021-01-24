    public class main_class
    {
        private static main_class instance;
        public delegate void MethodInvoker();
        public MethodInvoker MyInvoker { get; set; }
        public static main_class Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new main_class();
                }
                return instance;
            }
        }
        private main_class() { }
        public void invoke_all()
        {
            MyInvoker();
        }
    }
    public class test1
    {
        public test1()
        {
            main_class.Instance.MyInvoker += invoke;
        }
        public void invoke()
        {
            Console.WriteLine("test1 invoked");
        }
    }
    public class test2
    {
        public test2()
        {
            main_class.Instance.MyInvoker += invoke;
        }
        public void invoke()
        {
            Console.WriteLine("test2 invoked");
        }
    }
