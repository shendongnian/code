    public static string AppendDateTimeToFileName(this string fileName, string prefix, string uniqueNumber)
    {
        return string.Concat(               
            Path.Combine(Path.GetDirectoryName(fileName), prefix + " - " + uniqueNumber + " - "),
            DateTime.Now.ToString()
            .Replace(".", " ")
            .Replace(":", " ")
            .Trim(),
            Path.GetExtension(fileName)
            );
    }
