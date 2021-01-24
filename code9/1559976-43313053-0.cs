    private bool checkinternet()
    {
        using(WebRequest request = WebRequest.Create("http://www.google.com"))
        {
            WebResponse response;
            try
            {
                response = request.GetResponse();
                response.Close();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
