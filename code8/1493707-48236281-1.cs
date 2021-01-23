     #region CheckFileExist
        public static async Task<bool> IsFileExistAsync(string fileName, StorageFolder folder)
        {
            try
            {
                var item = await folder.TryGetItemAsync(fileName);
                return item != null;
            }
            catch
            {
                return false;
            }
        }
        #endregion
