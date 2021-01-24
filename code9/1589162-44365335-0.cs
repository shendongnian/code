    public static void SaveToTxt()
    {
        using (TextWriter tw = new StreamWriter(Path))
        {
            foreach (var item in Data.List)
            {
                tw.WriteLine(string.Format("{0} {1}", item.Name, item.Cost));
            }
        }
    }
