    private static void _SerializeConfig(string filePath, MyFancyPermissionConfig configuration)
    {
        try
        {
            var str = JsonConvert.SerializeObject(configuration, Formatting.Indented);
            var bytes = Encoding.UTF8.GetBytes(str);
            Console.WriteLine("Will serialize string:\n {0}" , str);
            byte[] fileBytes = Encrypt(bytes);
            File.WriteAllBytes(filePath, fileBytes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    private static MyFancyPermissionConfig _DeSerializeConfig(string filePath)
    {
        try
        {
            byte[] encryptedBytes = File.ReadAllBytes(filePath);
            byte[] fileBytes = Decrypt(encryptedBytes);
            var str = Encoding.UTF8.GetString(fileBytes);
            Console.WriteLine("Decrypted to: \n" + str);
            return JsonConvert.DeserializeObject<MyFancyPermissionConfig>(str);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
