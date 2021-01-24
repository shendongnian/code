    [assembly: Xamarin.Forms.Dependency(typeof(IFileAccessHelper))]
    namespace MyNamespace.Droid
    {
        class IFileAccessHelper : MyXamarinFormsPage.IFileAccessHelper
        {
            public async Task<String> GetDBPathAndCreateIfNotExists()
            {
                String databaseName = "MyLite.db";
                var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                var dbFile = Path.Combine(docFolder, databaseName); // FILE NAME TO USE WHEN COPIED
                if (!File.Exists(dbFile))
                {
                    FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                    await Forms.Context.Assets.Open(databaseName).CopyToAsync(writeStream);
                }
                return dbFile;
            }
        }
    }
