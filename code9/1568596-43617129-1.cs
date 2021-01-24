    public static long GetLongFromVersion(string VersionString) {
        string[] VersionSplit = VersionString.Split(' ');
        string VersionNumber = VersionSplit[1];
        string[] VersionBytes;
        double num = 0;
        if (!string.IsNullOrEmpty(VersionNumber)) {
            VersionBytes = VersionNumber.Split('.');
            for (int i = VersionBytes.Length - 1; i >= 0; i--) {
                num += ((int.Parse(VersionBytes[i]) % 256) * Math.Pow(256, (3 - i)));
            }
        }
        return (long)num;
    }
