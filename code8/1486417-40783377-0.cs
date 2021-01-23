    public static void CreateFile<T>(this List<T> lines, File_attribute fa)
    {
         File.WriteAllText
         (
              Path.Combine(fa.OutpoutFolder, fa.FileName),
              string.Join(Environment.NewLine, lines)
         );
    }
