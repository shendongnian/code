    public static string GetDataUri(string text, string contentType)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var b64String = Convert.ToBase64String(bytes);
        var dataUri = $"data:{contentType};base64,{b64String}";
        return dataUri;
    }
