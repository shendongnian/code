    void Awake()
    {
        //Enable Callback on the main Thread
        UnityThread.initUnityThread();
    }
    void isOnline(Action<bool> online)
    {
        bool success = true;
        //Use ThreadPool to avoid freezing
        ThreadPool.QueueUserWorkItem(delegate
        {
            try
            {
                int timeout = 2000;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.com");
                request.Method = "GET";
                request.Timeout = timeout;
                request.KeepAlive = false;
                request.ServicePoint.Expect100Continue = false;
                request.ServicePoint.MaxIdleTime = timeout;
                //Make sure Google don't reject you when called on mobile device (Android)
                request.changeSysTemHeader("User-Agent", "Mozilla / 5.0(Windows NT 10.0; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 55.0.2883.87 Safari / 537.36");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response == null)
                {
                    success = false;
                }
                if (response != null && response.StatusCode != HttpStatusCode.OK)
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }
            //Do the callback in the main Thread
            UnityThread.executeInUpdate(() =>
            {
                if (online != null)
                    online(success);
            });
        });
    }
