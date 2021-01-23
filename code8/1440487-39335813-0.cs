    private string DecodeFromBase64(string inputBas64)
    {
        var base64EncodedBytesPassword = System.Convert.FromBase64String(model.Password);
        string password = System.Text.Encoding.UTF8.GetString(base64EncodedBytesPassword);
        return password;
    }
