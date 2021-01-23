    public class MyClass
    {
        public static string src = @"C:\Users\Bold Defiance\Desktop\FolderA";
        public static string dst = @"C:\Users\Bold Defiance\Desktop\FolderB";
        public static string[] files = System.IO.Directory.GetFiles(src, "*.txt");
        public void Move_Modified_Files()
        {
            foreach (string s in files)
            {
                // These values will exist until their enclosing context is closed
                // The context starts with the most recent opening bracket {
                // So these values, will exist until this loop iterates to the next value
                string fileName = Path.GetFileName(s);
                FileInfo filesInfo = new FileInfo(fileName);
                // Attempt to use the currently selected fileinfo
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
                // The next } bracket below is the one that closes the context mentioned earlier
                // When it closes, all values declared in this sub-context will no longer exist.
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
