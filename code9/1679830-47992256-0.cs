    var filesDate = new DateTime[fileListfordiff.Length];
    var lowestDate = DateTime.MaxValue;
    var lowestDateIndex = -1;
    for(int i=0; i < fileListfordiff.Length; i++)
    {
        filesDate[i] = DateTime.ParseExact(fileListfordiff[i].Substring(22, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
        if(filesDate[i] < lowestDate)
        {
            lowestDate = filesDate[i];
            lowestDateIndex = i;
        }
    }
