    public static void ConvertByteExample()
    {
        byte[] imageData = File.ReadAllBytes("example.b64");
        string encodedString = System.Text.Encoding.UTF8.GetString(imageData); //<-- do this
        byte[] convertedData = Convert.FromBase64String(encodedString); 
        File.WriteAllBytes("output2.png", convertedData);
    }
