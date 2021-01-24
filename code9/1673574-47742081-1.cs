    using System.Net;
    using System.IO;
    void DownloadFileAndExecute(string link)
    {
      WebClient wc = New WebClient();
      string filename = Path.GetFileName(link);
      wc.DownloadFile(link, filename)
      Process.Start(filename)
    }
