    await Task.WhenAll(longList.Select(async s => {
        Console.WriteLine(i);
        string link = @"some link" + s + "/";
        try
        {
            if (!links.Contains(link))
            {
                await Download(link);
            }
        }
        catch (System.Exception e)
        {
        }
    }));
