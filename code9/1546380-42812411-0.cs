    public static bool TryParseDateTimeWithTimeZone(string s, out DateTime result, out string timeZone)
    {
        if (s == null)
        {
            throw new NullReferenceException("s");
        }
        int ixEnd = s.LastIndexOf(' ');
        if (ixEnd == -1 || ixEnd == 0)
        {
            throw new FormatException();
        }
        int ixStart = s.LastIndexOf(' ', ixEnd - 1);
        if (ixStart == -1)
        {
            throw new FormatException();
        }
        timeZone = s.Substring(ixStart + 1, ixEnd - ixStart - 1);
        string s2 = s.Remove(ixStart) + s.Substring(ixEnd);
        bool success = DateTime.TryParseExact(s2, "ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        if (!success)
        {
            timeZone = null;
        }
        return success;
    }
