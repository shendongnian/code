    const string fileName = "AppSettings.dat";
    static void Main()
    {
        string someText = "settings";
        byte[] byteArray = Encoding.UTF8.GetBytes(someText);
        for (int i = 0; i < byteArray.Length; i++)
        {
            byteArray[i] ^= 255;
        }
        File.WriteAllBytes(fileName, byteArray);
        if (File.Exists(fileName))
        {
            var x = File.ReadAllBytes(fileName);
            
            for (int i = 0; i < byteArray.Length; i++)
            {
                x[i] ^= 255;
            }
            string str = Encoding.UTF8.GetString(x);
            Console.Write(str);
            Console.ReadKey();
        }
    }
