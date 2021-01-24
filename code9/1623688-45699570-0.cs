    private static void Extract()
    {
        Uri uri = new Uri("http://somesite/somepage/johndoe21911");
        string last = uri.Segments.LastOrDefault();
        string numOnly = Regex.Replace(last, "[^0-9 _]", string.Empty);
        Console.WriteLine(last);
        Console.WriteLine(numOnly);
    }
