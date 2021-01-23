    public static void CreateFile<T>(this List<T> items, File_attribute fa)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(fa.OutpoutFolder + fa.FileName))
        {
            foreach (T item in items)
                file.WriteLine(item.ToString());
        }
    }
