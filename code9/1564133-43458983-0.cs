    using System.Data.Linq;
    public static Binary CalculateMD5HashBinary(this string input)
    {
        if (String.IsNullOrEmpty(input))
        {
            return null;
        }
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        return md5.ComputeHash(inputBytes);
    }
