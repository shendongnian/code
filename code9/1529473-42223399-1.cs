    public static WebResponse Request(Dictionary<string, string> parameters) {
            lock (thisLock)
            {
    
            string lastCalled = Session["LastCalledTime"] as string;
            if (!string.IsNullOrEmpty(lastCalled) && DateTime.Parse(lastCalled) >= DateTime.Now.AddSeconds(-1))
            {
                Sleep(1000);
            }
            Session["LastCalledTime"] = DateTime.Now.ToString("O");
            }
            var response = LaunchRequest(parameters);
            return response;
     }
