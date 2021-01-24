     public static bool IsInternetAvailable()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("YOUR_WEBSITE_NAME"))
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
