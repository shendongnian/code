    var config = new Dictionary<string, NameValueCollection>();
    foreach (Configuration c in lst)
    {
        NameValueCollection nvc;
        if(!config.TryGetValue(c.Name, out nvc))
        {
            nvc = new NameValueCollection();
            config.Add(c.Name, nvc);
        }
        nvc.Add(c.Config, c.Value);
    }
