    foreach (string ra in reqs)
    {
        for (int o = 0; o < reqs.Count; o++)
        {
            requestCounter = reqs.IndexOf(ra);
        }
        Uri uri = new Uri(ra);
        // Create the web request  
        HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
        // Get response  
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
            // Get the response stream  
            StreamReader reader = new StreamReader(response.GetResponseStream());
            // Console application output  
            Console.WriteLine(ra + " : " + reader.ReadToEnd());
        }
        if (requestCounter % 100 == 0) // Every 100th step
        {
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
        }
    }
