    HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(uri);
    request.Method = "HEAD";
    HttpWebResponse response = (HttpWebResponse) request.GetResponse();
    string disposition = response.Headers["Content-Disposition"];
    string filename = disposition.Substring(disposition.IndexOf("filename=") + 10).Replace("\"", "");
    response.close();
