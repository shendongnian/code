    bool search = true;
    while(search == true) {
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/test.php");
        request.CookieContainer = new CookieContainer(); // needed to keep the session alive
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string value = null;
        if (response.StatusCode == HttpStatusCode.OK)
        {
            
           
                for(int i = 0; i < response.Cookies.Count && search; i++)
                {
                    if (response.Cookies[i].Name == "test")
                    {
                        value = response.Cookies[i].Value;
                        search = false;
                    }
                }
            
        }
        if (value != null)
            Console.WriteLine("found cookie : {0}", value);
        response.Close();
}
