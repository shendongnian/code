    using (var webRes = client.Get<HttpWebResponse>(new DownloadRequest()))
    using (var stream = webRes.GetResponseStream())
    {
        var contentDisposition = webRes.Headers[HttpHeaders.ContentDisposition];
    }
