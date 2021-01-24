    [assembly: Xamarin.Forms.Dependency(typeof(IFileAccessHelper))]
    namespace MyNamespace.UWP
    {
        public class IFileAccessHelper : MyXamarinPage.IFileAccessHelper
        {
            public async Task<String> GetDBPathAndCreateIfNotExists()
            {
                String filename = "MyLite.db";
                bool isExisting = false;
                try
                {
                    StorageFile storage = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
                    isExisting = true;
                }
                catch (Exception)
                {
                    isExisting = false;
                }
                if (!isExisting)
                {
                    StorageFile databaseFile = await Package.Current.InstalledLocation.GetFileAsync(filename);
                    await databaseFile.CopyAsync(ApplicationData.Current.LocalFolder, filename, NameCollisionOption.ReplaceExisting);
                }
                return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
            }
        }
    }
