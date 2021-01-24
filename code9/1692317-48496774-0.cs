    public static string EnsureBackSlash(this string input)
    {
        return Path.GetFullPath(input)
            .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
            + Path.DirectorySeparatorChar;
    }
