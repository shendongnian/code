     public async Task<List<Miniature>> Load()
            {
                return await minidal.LoadAllAsync();
            }
    public async Task<List<Miniature>> LoadAllAsync()
            {
                
                List<Miniature> MiniCollection = new List<Miniature>();
                if (StorageApplicationPermissions.FutureAccessList.ContainsItem("PickedFolderToken"))
                {
                    try
                    {
                        var userFolder = await StorageApplicationPermissions.FutureAccessList.GetFolderAsync("PickedFolderToken");
                        var file = await userFolder.GetFileAsync("AllMinisList.json");
                        var data = await file.OpenReadAsync();
    
                        using (StreamReader stream = new StreamReader(data.AsStream()))
                        {
                            string text = stream.ReadToEnd();
                            MiniCollection = JsonConvert.DeserializeObject<List<Miniature>>(text);
                        }
                    }
                    catch(Exception e)
                    {
                        throw e;
                    }
                }
                else
                {
                    SetSaveFolder().Wait();
                    return MiniCollection;
                }
                
                return MiniCollection;
            }
