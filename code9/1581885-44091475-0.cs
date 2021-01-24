    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    
    namespace SillyCSharpNameSpace
    {
        public class VerboseDownloaderClassName
        {
            private string downloadFile(string url, string localDir)
            {
                try
                {
                    var localPath = Path.Combine(localDir, Path.GetFileName(url));
                    using (var wc = new WebClient())
                    {
                        wc.DownloadFile(url, localPath);
                        return localPath;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
            }
    
            public void DownloadAll(List<string> urls)
            {
                urls.AsParallel()
                    .Where(url => !string.IsNullOrWhiteSpace(url))
                    .WithDegreeOfParallelism(20)
                    .Select(url => downloadFile(url, "."));
            }
        }
    }
