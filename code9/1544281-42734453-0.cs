    static void apiReq()
    {
        string filePath = "Path To File\\a.txt";
        var fileLines = System.IO.File.ReadAllLines(filePath);          
        int requestCounter = 0; // Adding a counter
        foreach(string s in fileLines)
        {
             keyList.Add(s);
        }
    
        for (int ab = 0; ab < keyList.Count; ab++)
        {
            URLreq = Uri1 + keyList[ab];
            reqs.Add(URLreq);
    
        }
    
        foreach (string ra in reqs)
        {
            if (requestCounter % 100 == 0) // Every 100th step
            {
                Thread.Sleep(2000); // Wait for 2 seconds
            }
    
            Uri uri = new Uri(ra);
            // Create the web request  
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
    
            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // ..
            }
    
            requestCounter++; // Count upwards
        }
        // ..
    }
