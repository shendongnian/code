    var uri = new Uri("https://sometest.com/l/admin/ical.html?t=TD61C7NibbV0m5bnDqYC_q");
    string directory = "D:\\Data\\Name";
    WebClient webClient = new WebClient();  
    // make a request to server with `OpenRead`. This will fetch response headers but will not read whole response into memory          
    using (var stream = webClient.OpenRead(uri)) {
        // get and parse Content-Disposition header if any
        var cdRaw = webClient.ResponseHeaders["Content-Disposition"];
        string filePath;
        if (!String.IsNullOrWhiteSpace(cdRaw)) {
            filePath = Path.Combine(directory, new System.Net.Mime.ContentDisposition(cdRaw).FileName);
        }
        else {
            // if no such header - fallback to previous way
            filePath = Path.Combine(directory, uri.Segments[uri.Segments.Length - 1]);
        }
        // copy response stream to target file
        using (var fs = File.Create(filePath)) {
            stream.CopyTo(fs);
        }
    }
