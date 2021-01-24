    private static void Extract()
    {
        string uri = "http://somesite/somepage/johndoe21911";
        string last = uri.Substring(uri.LastIndexOf('/') + 1);
        string numOnly = Regex.Replace(last, "[^0-9 _]", string.Empty);
        Console.WriteLine(last);
        Console.WriteLine(numOnly);
    }
