    public static class gtu
    {
        private static readonly Lazy<string> mostsearchedpagedata =
           new Lazy<string>(
              () => {
                    using (WebClient client = new WebClient())
                    {
                       mostsearchpagedata = 
                          client.DownloadString("https://xxx.yxc");
                    }
              },
              // See https://msdn.microsoft.com/library/system.threading.lazythreadsafetymode(v=vs.110).aspx for more info
              // on the relevance of this.
              // Hint: since fetching a web page is potentially
              // expensive you really want to do it only once.
              LazyThreadSafeMode.ExecutionAndPublication
           );
    
        // Optional: provide a "wrapper" to hide the fact that Lazy is used.
        public static string MostSearchedPageData => mostsearchedpagedata.Value;
    
     }
