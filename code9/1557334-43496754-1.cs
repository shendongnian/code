     public class DMScreen3 {
        public List<string> AllFiles { get; set; }
                  List<BindingFilesContent> items = new List<BindingFilesContent>();
                        if(AllFiles != null)
                        {
                            foreach(var r in AllFiles)
                            {
                                if ((r.ToLower().Contains(".avi") || r.ToLower().Contains(".mp4")) && fileTypes == "video")
                                {
                                    items.Add(new BindingFilesContent() { Title = Path.GetFileName(r), UriPath = r, Source = "/images/videoicon.png" });
                                }
            icTodoList.ItemsSource = items;
                      }
            }
    }
      public class BindingFilesContent
        {
            public string Title { get; set; }
            public string Source { get; set; }
            public string UriPath { get; set; }
        }
