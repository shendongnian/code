    public void CalcHashes(string path)
    {
        string GetFileHash(System.Security.Cryptography.MD5 md5, string fileName)
        {
            using (var stream = new BufferedStream(System.IO.File.OpenRead(fileName), 1200000))
            {
                var hash = md5.ComputeHash(stream);
                var fileMD5 = string.Concat(Array.ConvertAll(hash, x => x.ToString("X2")));
                return fileMD5;
            }
        }
        Parallel.ForEach(filenames, fileName =>
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                GetFileHash(md5, fileName);
            }
        });
    }
