    public string GetSent()
    {
        foreach (var line in File.ReadLines("sample.txt")) // replace with your path
        {
            if (line.StartsWith("Sent:"))
            {
                return line.Substring(5);
            }
        }
        return "NOT FOUND"; // or null or whatever you want to default to
    }
