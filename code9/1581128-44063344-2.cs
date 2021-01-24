    if(finalFile.Any(s => s.MainId == mainOnly.ParsedName))
    {
        finalCollection.ClientName = mainOnly.ClientName;
        finalCollection.MainId = mainOnly.ParsedName;
        //finalCollection.WavName = Convert.ToInt64(wav.ParsedName);
        finalCollection.LastWriteTime = mainOnly.CreationTime;
        finalCollection.folder = mainOnly.FolderName;
        mainAll.Add(finalCollection);
    }
