    public static void RegisterUserCreds()
    {
        string[] creds = { Username.Text, Password.Text };
        string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        if (!Directory.Exists(roaming + "/Launcher")) Directory.CreateDirectory(roaming + "/Launcher");
        string specificFolder = roaming + "/Launcher/user_info.txt";
        using (var fs = File.Open(specificFolder, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine(Username.Text);
            }
        }
    }
