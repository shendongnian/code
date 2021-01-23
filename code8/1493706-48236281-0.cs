    public class SQLiteDatabase
    {       
        
        private static string dbPath = string.Empty;
        private static string DBPath(string fileName)
        {
            if (string.IsNullOrEmpty(dbPath))
            {
                dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, fileName);
            }
            return dbPath;
        }
        /// <summary>
        /// Get fileName From LocalFolder. Please Create first a dataBase.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SQLiteConnection DbConnection(string fileName)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DBPath(fileName));
        }
       
        //Installed Location.
        private static string dbPathStatic = string.Empty;
        private static string DBPathStatic(string path)
        {
            if (string.IsNullOrEmpty(dbPathStatic))
            {                            
                dbPathStatic = Path.Combine(Package.Current.InstalledLocation.Path, path);
            }
            return dbPathStatic;
        }
        /// <summary>
        /// Get fileName Path from Installed location. Note Add @ in path e.g( @"Data\Data.dta or (@"Shared\Data\Data.dta) if in Class Library), Make Data.dta Build to Content in Properties.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SQLiteConnection DbConnectionPackage(string path)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DBPathStatic(path));
        }
        //Roaming Location
        private static string dbPathRoaming = string.Empty;
        private static string DBPathRoaming(string fileName)
        {
            if (string.IsNullOrEmpty(dbPathRoaming))
            {
                dbPathRoaming = Path.Combine(Windows.Storage.ApplicationData.Current.RoamingFolder.Path, fileName);
            }
            return dbPathRoaming;
        }
        /// <summary>
        /// Get fileName Path. Please Create first a dataBase.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SQLiteConnection DbConnectionRoaming(string fileName)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DBPathRoaming(fileName));
        }
        //CustomFolder Location
        private static string dbPathCustomFolder = string.Empty;
        private static string DBPathCustomFolder(string fileName, StorageFolder CustomFolder)
        {
            if (string.IsNullOrEmpty(dbPathCustomFolder))
            {
                dbPathCustomFolder = Path.Combine(CustomFolder.Path, fileName);
            }
            return dbPathCustomFolder;
        }
        /// <summary>
        /// Get fileName Path. Please Create first a dataBase.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static SQLiteConnection DbConnectionCustomFolder(string fileName, StorageFolder knownFolder)
        {
            return new SQLiteConnection(new SQLitePlatformWinRT(), DBPathCustomFolder(fileName, knownFolder));
        }
