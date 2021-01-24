    public class MyAppSettings
    {
        
        public string SaveDir
        { 
            get
            {
            if(Properties.Settings.Default.SaveDir.Equals(String.Empty))
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
            return Properties.Settings.Default.SaveDir;
            }
       }
    }
