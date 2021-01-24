    namespace ConsoleApplication3
    {
        class Program
        {
            private IArithmetic InterfaceReference;
    
            public Program(IArithmetic InterfaceReferenceParam)
            {
                InterfaceReference = InterfaceReferenceParam;
            }
    		
    		public void Run()
    		{
                int output = InterfaceReference.DoOperation(5, 2);
                Console.Write(output);
                Console.WriteLine();
    			
    		}
            static void Main(string[] args)
            {
                IUnityContainer myContainer = new UnityContainer();
                myContainer.RegisterType<IArithmetic, Addition>();
                myContainer.RegisterType<Program, Program>();
    			var program = myContainer.Resolve<Program>();
    			program.Run();
            }
        }
    }
