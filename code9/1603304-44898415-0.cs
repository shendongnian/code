    using Newtonsoft.Json.Linq;
    string albumurl = Uri.EscapeUriString("https://www.metal-archives.com/search/ajax-album-search/?field=title&query=rust+in+peace");
    string doc = "";
    using (System.Net.WebClient client = new System.Net.WebClient()) // WebClient class inherits IDisposable
    {
        doc = client.DownloadString(albumurl);
    }
