    internal class Program
    {
        public static void DoStuff()
        {
            string x = "";
            string y = "";
            string fileName = "C:\\temp\\tempfile.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            int a = 43;
            int b = 37;
            int c = -38;
            if (x != null)
            {
                lock (lockObj)
                {
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.WriteLine(a + "," + b + "," + c);
                        sw.Close();
                        sw.Flush();
                    }
                }
            }
            if (y != null)
            {
                lock (lockObj)
                {
                    using (StreamWriter sw1 = new StreamWriter(fileName))
                    {
                        sw1.WriteLine(a + "," + b + "," + c);
                        sw1.Close();
                        sw1.Flush();
                    }
                }
            }
        }
        protected static Object lockObj = new Object();
        static void Main(string[] args)
        {
            DoStuff();
        }
    }
