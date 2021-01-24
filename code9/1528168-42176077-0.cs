    public static void WriteLine(string path, object o, bool append = false)
    {
        WriteLine(path, o.ToString(), append);
    }
    public static void WriteLine(string path, string s, bool append = false)
    {
        using (var file = new StreamWriter(path, append))
        {
            file.WriteLine(s);
        }
    }
    public static void WriteLine(string path, IEnumerable e, bool append = false)
    {
        using (var file = new StreamWriter(path, append))
        {
            foreach (var o in e)
            {
                file.WriteLine(o.ToString());
            }
        }
    }
