    public class Loader : MarshalByRefObject
    {
        public Assembly TempAssembly { get; set; }
        public string Execute(string dllPath)
        {
            TempAssembly = Assembly.LoadFile(dllPath);
            return TempAssembly.FullName;
        }
        public void CompareTwoDLLs(Loader l2)
        {
            var types1 = TempAssembly.GetTypes();
            var types2= l2.TempAssembly.GetTypes();
            //logic to return comparison result
        }
     }
