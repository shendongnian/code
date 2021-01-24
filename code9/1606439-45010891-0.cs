    public static void isURLExist(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse res = req.GetResponse();
                Console.WriteLine("Url Exists");
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.Message.Contains("remote name could not be resolved"))
                {
                    Console.WriteLine("Url is Invalid");
                }
            }
        }
