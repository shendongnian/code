    string url = "http://www.yourUrl.com";
    string savePath = Path.Combine(Application.dataPath, "file.txt");
    int downloadID = 0;
    #if !UNITY_WSA_10_0
    //Will be used on Platforms other than Hololens
    void downloadFile()
    {
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DoSomethingOnFinish);
        webClient.QueryString.Add("fileName", downloadID.ToString());
        Uri uri = new Uri(url);
        webClient.DownloadFileAsync(uri, savePath);
        downloadID++;
    }
    void DoSomethingOnFinish(object sender, AsyncCompletedEventArgs e)
    {
        string myFileNameID = ((System.Net.WebClient)(sender)).QueryString["fileName"];
    }
    #else
    //Will be used on Hololens
    void downloadFile()
    {
        StartCoroutine(downloadFileCOR());
    }
    IEnumerator downloadFileCOR()
    {
        WWW www = new WWW(url);
        yield return www;
        Debug.Log("Finished Downloading file");
        byte[] yourBytes = www.bytes;
        //Now Save it
        System.IO.File.WriteAllBytes(savePath, yourBytes);
    }
    #endif
