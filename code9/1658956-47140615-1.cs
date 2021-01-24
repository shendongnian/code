    public class Manager
    {
    public static async Task<int> ErstellltbilderlisteAsync(StorageFolder quelle)
            {
                int idcounter = 0;
    
                var query = quelle.CreateFileQuery();
                var fileList = await query.GetFilesAsync();
                foreach (StorageFile file in fileList)
                {
                    idcounter++;
                    
                }
                return idcounter;
    }
    }
