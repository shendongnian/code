    [assembly: Xamarin.Forms.Dependency(typeof(FileAccessHelper))]
    namespace MyNamespace.iOS
    {
        public class FileAccessHelper : MyXamarinFormsPage.IFileAccessHelper
        {
            public async Task<String> GetDBPathAndCreateIfNotExists()
            {
                String databaseName = "MyLite.db";
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var path = Path.Combine(documentsPath, databaseName);
                if (!File.Exists(path))
                {
                    var existingDb = NSBundle.MainBundle.PathForResource("MyLite", "db");
                    File.Copy(existingDb, path);
                }
                return path;
            }
        }
    }
