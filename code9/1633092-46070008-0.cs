    public static void CopyBlob([BlobTrigger("input/{name}")] TextReader input,
        [Blob("output/{name}")] out string output)
    {
        output = input.ReadToEnd();
    }
