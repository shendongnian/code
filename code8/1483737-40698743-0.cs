    var encstr = Enc("MyTextToHide", "MyKey");
    var decstr = Dec(encstr, "MyKey");
------
    static string Enc(string plaintext, string pad)
    {
        var data = Encoding.UTF8.GetBytes(plaintext);
        var key = Encoding.UTF8.GetBytes(pad);
        return Convert.ToBase64String(data.Select((b, i) => (byte)(b ^ key[i % key.Length])).ToArray());
    }
    static string Dec(string enctext, string pad)
    {
        var data = Convert.FromBase64String(enctext);
        var key = Encoding.UTF8.GetBytes(pad);
        return Encoding.UTF8.GetString(data.Select((b, i) => (byte)(b ^ key[i % key.Length])).ToArray());
    }
