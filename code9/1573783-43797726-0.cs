    internal static string WindowsToIana(string windowsZoneId)
    {
        // Avoid UTC being mapped to Etc/GMT, which is the mapping in CLDR
        if (windowsZoneId == "UTC")
        {
            return "Etc/UTC";
        }
        var source = TzdbDateTimeZoneSource.Default;
        string result;
        // If there's no such mapping, result will be null.
        source.WindowsMapping.PrimaryMapping.TryGetValue(id, out result);
        // Canonicalize
        if (result != null)
        {
            result = source.CanonicalIdMap[result];
        }
        return result;
    }
