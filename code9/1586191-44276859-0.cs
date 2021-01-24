    private static string GetSharedAccessSignature(
           string accountName,
           string accountkey,
           string blobContainer,
           string blobName,
           DateTimeOffset sharedAccessStartTime,
           DateTimeOffset sharedAccessExpiryTime)
    {
        var canonicalNameFormat = $"/blob/{accountName}/{blobContainer}/{blobName}";
        var st = sharedAccessStartTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        var se = sharedAccessExpiryTime.UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ssZ");
        var sasVersion = "2016-05-31";
    
        string stringToSign = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}\n{8}\n{9}\n{10}\n{11}\n{12}", new object[]
        {
            "r",
            st,
            se,
            canonicalNameFormat,
            string.Empty,
            string.Empty,
            string.Empty,
            sasVersion,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        });
    
        var sas = GetHash(stringToSign, accountkey);
    
        var credentials =
            $"?sv={sasVersion}&sr=b&sig={UrlEncoder.Default.Encode(sas)}&st={UrlEncoder.Default.Encode(st)}&se={UrlEncoder.Default.Encode(se)}&sp=r";
    
        string blobUri = $"https://{accountName}.blob.core.windows.net/{blobContainer}/{blobName}";
        return blobUri + credentials;
    }
    
    private static string GetHash(string stringToSign, string key)
    {
        byte[] keyValue = Convert.FromBase64String(key);
    
        using (HMACSHA256 hmac = new HMACSHA256(keyValue))
        {
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
        }
    }
