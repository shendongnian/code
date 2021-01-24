    public void Process(string file)
    {
        using (var stream = new FileStream(file, FileMode.Open))
        {
            this.Process(stream);
        }
    }
