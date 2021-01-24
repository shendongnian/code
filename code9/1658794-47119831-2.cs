    internal class Program
    {
        public static void DoStuff()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            if (x != null)
            {
                lock (lockObj)
                {
                    WriteStuff();
                }
            }
            if (y != null)
            {
                lock (lockObj)
                {
                    WriteStuff();
                }
            }
        }
 
        private static string fileName = "C:\\temp\\tempfile.txt";
        private static object lockObj = new object();
        private static string x = "";
        private static string y = "";
        static void Main(string[] args)
        {
            DoStuff();
        }
        static void WriteStuff()
        {
            using (StreamWriter sw1 = new StreamWriter(fileName))
            {
                sw1.WriteLine("irrelevant");
            }
        }
    }
