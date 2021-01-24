    public bool CheckIfUp(string encodedUrl)
    {
         WebRequest request;
         WebResponse ws;
         Response response = new Response();
         string url = "http://servicePath/isUp"; // your wcf url
         try
           {
                    request = WebRequest.Create(url);
                    ws = request.GetResponse();
                    return (response.ID == 200);
           }
           catch (Exception e)
           {
                    Console.Write(e.StackTrace);
           }
                return false;
     }
