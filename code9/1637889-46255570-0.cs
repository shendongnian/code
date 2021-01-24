    using (WebClient wc = new WebClient())
    {
        var nvc = new NameValueCollection();
        nvc.Add("pdf-parameter", "encoded-pdf-here");
        // UploadValues uses 'POST' by default
        var data = wc.UploadValues(url, nvc);
        // Adjust result encoding if required...
        var result = Encoding.UTF8.GetString(data);
    }
