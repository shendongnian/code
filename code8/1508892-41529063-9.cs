    public class Helper : MarshalByRefObject
    {
        public void LoadAssembly(Byte[] data)
        {
            var a = Assembly.Load(data);
            a.EntryPoint.Invoke(null, null);
        }
    }
