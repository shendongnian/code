    Blocking<string> links= new BlockingCollection<string>();\\ using System.Collections.Concurrent;
    Blocking<string> results= new BlockingCollection<string>();
    public static void main()
    {
    //get your datatable
           for (int i = 0; i < dt.Rows.Count; i++)
            {
            ThreadStart t = new ThreadStart(threads);
          Thread th = new Thread(t);
            th.Start();
            }
           for (int i = 0; i < dt.Rows.Count; i++)
            {
            links.add(dt.Rows[i]["link"].ToString());
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               dt.Rows[i]["Details"] = results.Take();
              }
    }
    public void threads()
    {
    while(true)
     {
      string url= Links.take();//block if links is empty
      var html = new HtmlAgilityPack.HtmlDocument();
      string text= html.LoadHtml(new WebClient().DownloadString(url));
      results.add(text);//add result to the other queue
     }
    }
