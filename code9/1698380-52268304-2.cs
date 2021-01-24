    IEnumerable<string> FindMatchingBinaries(string path, string filename)
    {
        var checksum = GetChecksum(filename);
        return FindBinaries(path).Select(p => p.FullName).Where(name => GetChecksum(name) == checksum);
    }
