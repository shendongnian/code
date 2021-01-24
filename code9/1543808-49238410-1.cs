    public static int version = 1;
        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += Program.CurrentDomain_AssemblyResolve;
            version = 1;
            Type a = Type.GetType("MathFuncs.Add, MathFuncs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            MethodInfo methodInfo = a?.GetMethod("add");
            object result = null;
            if (methodInfo != null)
            {
                object[] parametersArray = new object[] {1, 2};
                result = methodInfo.Invoke(Activator.CreateInstance(a, null), parametersArray);
            }
            if (result != null)
            {
                Console.WriteLine((int)result);
            }
            else
            {
                Console.WriteLine("failed");
            }
            Console.Read();
        }
        
        public static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            FileInfo fi = null;
            if (version == 1)
            {
                fi = new FileInfo("C:\\Users\\ohbitton\\Desktop\\MathFuncs\\MathFuncs.dll");
            }
            else
            {
                fi = new FileInfo("C:\\Users\\ohbitton\\Desktop\\MathFuncs2\\MathFuncs.dll");
            }
            return Assembly.LoadFrom(fi.FullName);
            
        }
