    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch (Exception exception)
            {
                // the file will be written in your execution path.
                string path = "error.txt";
                // if you don't have the rights to write in the execution path, uncomment this line and comment the other path line.
                // the file will then be located at: C:\Users\YourUserName\AppData\Local\error.txt
                //string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\error.txt";
                if (File.Exists(path))
                    File.Delete(path);
                var sb = new StringBuilder();
                while (exception != null)
                {
                    sb.AppendLine(exception.ToString());
                    sb.AppendLine(exception.Message);
                    sb.AppendLine();
                    exception = exception.InnerException;
                }
                File.WriteAllText(path, sb.ToString());
                throw;
            }
        }
    }
