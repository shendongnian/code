    if (cacheExpiry > DateTime.Now)
        return new MemoryStream(Encoding.UTF8.GetBytes(cachedResponse));
    // the rest of your method to query the service
    // then...
    cachedResponse = client.DownloadString(url);
    cacheExpiry = DateTime.Now.AddMinutes(30);
    return new MemoryStream(Encoding.UTF8.GetBytes(cachedResponse));
