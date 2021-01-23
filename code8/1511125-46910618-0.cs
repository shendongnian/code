    class MyClass
    {
        IWebRequestCreate _web;
        public MyClass(IWebRequestCreate web)
        {
           _web = web;
        }
        public void Download(string url)
        {
           var request = _web.Create(url);
        }
    }
