    public class AppSettingsManager : IAppSettingsManager
    {
        private static string filesFolder;
        public static string FilesFolder
        {
            get
            {
                if (filesFolder == null)
                {
                    filesFolder = filesFolder = ConfigurationManager.AppSettings["FilesFolder"];
                }
                return filesFolder;
            }
        }
    }
