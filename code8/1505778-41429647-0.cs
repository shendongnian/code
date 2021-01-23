    class Program
    {
        static void Main(string[] args)
        {
            Start<WorkerClass>();
        }
    
        public static void Start<T>() where T : iBase
        {
            iBase workerClass = (iBase)Activator.CreateInstance(typeof(T));
    
            workerClass.DoWork("tst");
        }
    }
