    string GetChecksum(string filename)
    {
        string checksum = null;
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                checksum = BitConverter.ToString(md5.ComputeHash(stream));
            }
        }
        return checksum;
    }
