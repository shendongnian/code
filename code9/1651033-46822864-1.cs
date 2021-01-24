    public static async Task<StorageFile> GetDataFileFromLocalFolderAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException("fileName missing"); //remove hard coded string here
            }
            var sFolder = ApplicationData.Current.LocalFolder;
            var sFileTask = sFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            var sFile = sFileTask.AsTask().Result;
            return sFile;
        }
