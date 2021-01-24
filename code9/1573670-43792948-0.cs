    static void Main(string[] args)
    {
        string file = "C:\\CUWCDFileStorage\\temp\\test.png";
        var bytes = File.ReadAllBytes(file);
        using (var stream = File.Open(file, FileMode.Open))
        {
            Console.WriteLine(Md5HashFile(bytes));
            Console.WriteLine(Md5HashFile(stream));
        }
        using (var stream = File.Open(file, FileMode.Open))
        {
            Console.WriteLine(Sha1HashFile(bytes));
            Console.WriteLine(Sha1HashFile(stream));
            Console.WriteLine(Sha1HashFile2(bytes));
        }
        Console.Read();
    }
    public static string Md5HashFile(byte[] file)
    {
        using (MD5 md5 = MD5.Create())
        {
            return BitConverter.ToString(md5.ComputeHash(file)).Replace("-", "");
        }
    }
    public static string Sha1HashFile(byte[] file)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            return BitConverter.ToString(sha1.ComputeHash(file)).Replace("-", "");
        }
    }
    public static string Md5HashFile(Stream stream)
    {
        using (MD5 md5 = MD5.Create())
        {
            return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "");
        }
    }
    public static string Sha1HashFile(Stream stream)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            return BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", "");
        }
    }
    public static string Sha1HashFile2(byte[] bytes)
    {
        string file = "C:\\CUWCDFileStorage\\temp\\test2.png";
        File.WriteAllBytes(file, bytes);
        return Sha1HashFile(File.OpenRead(file));
    }
