    static void Main(string[] args)
    {
        var encrypted = Encrypt("this will be encrypted");
        Console.WriteLine("Encrypted base64: " + encrypted);
        Console.WriteLine();
        var unencrypted = Unencrypt(encrypted);
        Console.WriteLine("Decrypted: " + unencrypted);
        Console.ReadLine();
    }
    static string Encrypt(string valueToEncrypt)
    {
        var toEncrypt = System.Text.Encoding.UTF8.GetBytes(valueToEncrypt);
        var encryptedData = System.Web.Security.MachineKey.Protect(toEncrypt, null);
        var result = Convert.ToBase64String(encryptedData);
        return result;
    }
    static string Unencrypt(string value)
    {
        var toUnencrypt = Convert.FromBase64String(value);
        var deencryptedData = System.Web.Security.MachineKey.Unprotect(toUnencrypt, null);
        var originalValue = System.Text.Encoding.UTF8.GetString(deencryptedData);
        return originalValue;
    }
