    #if NETFX_CORE
            public static string ReadFile(string filename)
            {
                var task = LoadFileAsync(filename);
    
                Task.WaitAll(task);
    
                return task.Result;
            }
    
            private static async Task<string> LoadFileAsync(string filename)
            {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
    
                return await FileIO.ReadTextAsync(file);
            }
    #endif
