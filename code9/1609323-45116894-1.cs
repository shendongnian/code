    public string GetStarBox(int width, int height)
    {
        IEnumerable<string> lines = Enumerable.Repeat(new string('*', width), height);
        return String.Join(lines, '\n');
    }
