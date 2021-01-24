    //From https://stackoverflow.com/a/278457/1663001:
    public string GetTemporaryDirectory()
    {
        string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDirectory);
        return tempDirectory;
    }
    public string GetNonexistantPath()
    {
        return Path.Combine(GetTemporaryDirectory(), "no-such-file");
    }
