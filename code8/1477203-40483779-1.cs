    class Program
    {
        public static void Main()
        {
            AssemblyHelper.GetEntryAssembly = () => typeof(Program).GetAssembly();
    
            ....
        }
    }
