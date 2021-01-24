    using (var client = new HttpClient())
    using (var response = await client.GetAsync(url))
    using (var content = response.Content)
    using (var stream = await content.ReadAsStreamAsync())
    {
        // NOTE passing a stream here, not a string
        var directories = ImageMetadataReader.ReadMetadata(stream);
        // ...
    }
