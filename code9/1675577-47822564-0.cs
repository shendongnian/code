     foreach (var url in Sources_URL)
     {
         names.Add("------- Do stuff for : " + url.url_root);
         // Some Stuff
         Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate)
     }
    
    private static Action EmptyDelegate = delegate() { };
