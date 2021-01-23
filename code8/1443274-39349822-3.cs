    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        string dllPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "filenameofdll.dll");
        if (!File.Exists(dllPath))
        {
            byte[] fileBytes = Properties.Resources.<resourcename>;
            File.WriteAllBytes(dllPath, fileBytes);  
        }
        Application.Run(new Form1());
    }
