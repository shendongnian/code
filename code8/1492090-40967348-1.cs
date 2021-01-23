    public async Task DeleteSingleById(int id)
    {
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        StorageFile file = await folder.GetFileAsync("Data.xml");
        Stream stream = await file.OpenStreamForWriteAsync();
    
        using (stream)
        {
            XDocument doc = XDocument.Load(stream);
            doc.Descendants("Companies").Elements("Company").FirstOrDefault(x => x.Elements("Id").Any(e => e.Value == id.ToString())).Remove();
    
            stream.SetLength(0);
    
            doc.Save(stream);
        }
    }
