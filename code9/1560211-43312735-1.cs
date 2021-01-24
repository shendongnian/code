    public static Tuple<string, string> OpenTextFile(IFileSelector selector)
        {
    
            selector.Filter = "Text |*.txt";
            bool? accept = selector.SelectFile()
            if (accept == true)
                return Tuple.Create(File.ReadAllText(selector.FileSelected, Encoding.UTF8), selector.FileSelected);
            else
                return null;
        }
