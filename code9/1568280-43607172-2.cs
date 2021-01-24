    int chunkSize = 15000;
    var splitted = FullFileQuery.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    int chunks=splitted.Length/chunkSize; //Get number of chunks 
    for (int i=0;i<chunks;i++)
    {                
        sQuerys.Add(string.Join(Environment.NewLine,splitted
                                .Skip(i * chunkSize) //skip the already added lines
                                .Take(chunkSize))); //take the new lines
    }
