    namespace ConsoleApplication1
    {
        public class main_class
        {
            static void Main(string[] args)
            {
                main_class.invoke_all();
            }
            public static void invoke_all()
            {
                // call all the invokes
                foreach (Type mytype in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                     .Where(mytype => mytype.GetInterfaces().Contains(typeof(IInvokeAll))))
                {
                    mytype.GetMethod("invoke").Invoke(Activator.CreateInstance(mytype, null), null);
                }
                //wait for user input
                Console.ReadLine();
            }
        }
        interface IInvokeAll
        {
            void invoke();
        }
        public class test1 : IInvokeAll
        {
            //[invoke]
            public void invoke()
            {
                Console.WriteLine("test1 invoked");
            }
        }
        public class test2 : IInvokeAll
        {
            //[invoke]
            public void invoke()
            {
                Console.WriteLine("test2 invoked");
            }
        }
    }
