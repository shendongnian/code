    public IEnumerator<person> GetEnumerator()
    {
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while(!file.EndOfStream)
        {
            yield return new person(file.ReadLine());
        }
    }
