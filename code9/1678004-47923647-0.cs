    using(var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
    {
        foreach(string name in key.GetSubKeyNames())
        {
            using (var subkey = key.OpenSubKey(name))
                Console.WriteLine(subkey.GetValue("ProfileImagePath"))
        } 
    }
