    static void Main(string[] args)
    {
        try
        {
            string filePath = ConfigurationManager.AppSettings["filePath"],
                folder = ConfigurationManager.AppSettings["folder"];
            Directory.CreateDirectory(folder);
            List<string> urls = File.ReadAllLines(filePath).Take(10000).ToList();
    
            int urlIX = -1;
            Task.WaitAll(Enumerable.Range(0, 50).Select(x => Task.Factory.StartNew(() =>
              {
                  try
                  {
                      while (true) // ** was unprotected
                      {
                          int curUrlIX = Interlocked.Increment(ref urlIX);  // ** was unprotected
                          if (curUrlIX >= urls.Count)   // ** was unprotected
                              break;                    // ** was unprotected
                          string url = urls[curUrlIX];  // ** was unprotected
                          try
                          {
                              var req = (HttpWebRequest)WebRequest.Create(url);
                              using (var res = (HttpWebResponse)req.GetResponse())
                              using (var resStream = res.GetResponseStream())
                              using (var fileStream = File.Create(Path.Combine                    (folder, Guid.NewGuid() + url.Substring(url.LastIndexOf('.')))))
                                  resStream.CopyTo(fileStream);
                          }
                          catch (Exception ex)
                          {
                              Console.WriteLine("Error downloading img: " + url + "\n" + ex);
                              continue;
                          }
                      } // while
                  } // try
              })).ToArray());
        }
        catch
        {
            Console.WriteLine("Something bad happened.");
        }
    }
