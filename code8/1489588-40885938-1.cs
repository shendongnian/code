    static void Main(string[] args)
    {
        try
        {
            foreach (var proc in Process.GetProcessesByName("devenv"))
            {
                var files = Win32Processes.GetFilesLockedBy(proc);
                Regex rgxDbFile = new Regex("\\.opendb$", RegexOptions.IgnoreCase);
                foreach (var item in files.Where(f => rgxDbFile.IsMatch(f)))
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadKey(true);
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
