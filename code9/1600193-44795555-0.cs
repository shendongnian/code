    private async void btnuri_Click(object sender, RoutedEventArgs e)
    {
        string ext;
        ext = await GetFileExtention("https://i.stack.imgur.com/7e3M5.jpg?s=328&g=1");
        System.Diagnostics.Debug.WriteLine(ext);
        ext = await GetFileExtention("https://channel9.msdn.com/Events/Build/2017/T6056/captions?f=webvtt&l=en");
        System.Diagnostics.Debug.WriteLine(ext);
        ext = await GetFileExtention("https://code.msdn.microsoft.com/windowsapps/Background-File-Downloader-a9946bc9/file/145559/1/BackgroundDownloader.zip");
        System.Diagnostics.Debug.WriteLine(ext); 
    }
    public async Task<String> GetFileExtention(string url)
    {
        string ext = "";
        try
        {
            if (Path.HasExtension(url))
            {
                ext = Path.GetExtension(url);
                ext = ext.Contains('?') || ext.Contains('=') ? ext.Substring(0, ext.LastIndexOf("?")) : ext;
            }
            else
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(new Uri(url));
                IHttpContent res = response.Content;
                string ContentType = res.Headers["Content-Type"];
                string MimeType = ContentType.Substring(0, ContentType.LastIndexOf(";"));
                switch (MimeType)
                {
                    case "text/plain":
                        ext = ".txt"; break;
                    case "text/vtt":
                        ext = ".vtt"; break;
                    case "application/xml":
                        ext = ".aspx"; break;
                    case "text/html":
                        ext = "html"; break;
                    default:
                        ext = ".unknown"; break;
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
        return ext;
    }
