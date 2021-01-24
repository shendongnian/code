    private string DecodeBase64String(string encodedString)
    {
        var encodedStringWithoutTrailingCharacter = encodedString.Substring(0, encodedString.Length - 1);
        var encodedBytes = Microsoft.AspNetCore.WebUtilities.WebEncoders.Base64UrlDecode(encodedStringWithoutTrailingCharacter);
        return HttpUtility.UrlDecode(encodedBytes, Encoding.UTF8);
    }
