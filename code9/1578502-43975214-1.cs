    public string Upload(Input input)
    {
        File.WriteAllBytes(input.fileName, input.fileContents);
        return "OK";
    }
