    public static bool IsAllowedMimeType(this string base64string) 
    {
        if (string.IsNullOrWhiteSpace(base64string)
        {
            return false;
        }
        string data = base64string.Substring(0,5);
        switch (data.ToUpper()) 
        {
            case "IVBOR":
                //png
                return true;
                break;
            case "/9J/4":
                //jpg
                return true;
                break;
            case "JVBER":
                //pdf
                return true;
                break;
            default:
                //other types
                return false;
        }
    }
