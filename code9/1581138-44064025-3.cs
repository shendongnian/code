        public static async Task CopyDatabaseAsync(Activity activity)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "YOUR_DATABASENAME");
            if (!File.Exists(dbPath))
            {
                try
                {
                    using (var dbAssetStream = activity.Assets.Open("YOUR_DATABASENAME"))
                    using (var dbFileStream = new FileStream(dbPath, FileMode.OpenOrCreate))
                    {
                        var buffer = new byte[1024];
                        int b = buffer.Length;
                        int length;
                        while ((length = await dbAssetStream.ReadAsync(buffer, 0, b)) > 0)
                        {
                            await dbFileStream.WriteAsync(buffer, 0, length);
                        }
                        dbFileStream.Flush();
                    }
                }
                catch (Exception ex)
                {
                    //Handle exceptions
                }
            }
        }
