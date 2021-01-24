    public static string BlowfishDecrypt(string encrypted, string key)
    {
        var cipher = new BufferedBlockCipher(new BlowfishEngine());
        var k = new KeyParameter(Encoding.UTF8.GetBytes(key));
        cipher.Init(false, k);
        var input = Convert.FromBase64String(encrypted);
        var length = cipher.GetOutputSize(input.Length);
        var block = new byte[length];
        var len = cipher.ProcessBytes(input, 0, input.Length, block, 0);
        var output = cipher.DoFinal(block, len);
        // dont know how we get the real length of the content here... but this will do it. But I am sure there is a better way...
        var idx = Array.IndexOf(block, (byte)0);
        var str1 = Encoding.UTF8.GetString(block, 0, idx);
        var raw1 = Encoding.GetEncoding("iso-8859-1").GetBytes(str1);
        var str2 = Encoding.UTF8.GetString(raw1);
        return str2;
    }
    static string original = "@€~>|";
    static string encrypted_with_utf8_encode = "7+XyF+QGcA8lz5AQlLf1FA==";
    static string encrypted_without = "3oWsAOEF+Kc=";
    static string key = "t0ps3cr3t";
    public static void Main()
    {
        var decrypted1 = BlowfishDecrypt(encrypted_with_utf8_encode, key);
        var decrypted2 = BlowfishDecrypt(encrypted_without, key);
        var same = original.Equals(decrypted1);
        Debugger.Break();
    }
