    public static Boolean InternetAvailable()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                using (client.OpenRead("http://www.google.com/"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }
