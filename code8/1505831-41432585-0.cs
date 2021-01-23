    public class MyClass
    {
        public static string src = @"C:\Users\Bold Defiance\Desktop\FolderA";
        public static string dst = @"C:\Users\Bold Defiance\Desktop\FolderB";
        public static string[] files = System.IO.Directory.GetFiles(src, "*.txt");
        public void Move_Modified_Files()
        {
            foreach (string s in files)
            {
                string fileName = Path.GetFileName(s);
                FileInfo filesInfo = new FileInfo(fileName);
                try
                {
                    if (filesInfo.LastWriteTime.Date == DateTime.Today.Date)
                    {
                        File.Move(src, dst);
                        Console.WriteLine("Modified files in {0} were moved to {1}", src, dst);
                    }
                    else
                    {
                        Console.WriteLine("No new or modified files were created today.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass cls = new MyClass();
            cls.Move_Modified_Files();
        }
    }
