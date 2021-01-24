    public Text text;
    int fileID = 0;
    
    void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    void Start()
    {
        string url = "http://www.sample-videos.com/text/Sample-text-file-10kb.txt";
        string savePath = Path.Combine(Application.dataPath, "file.txt");
    
        downloadFile(url, savePath);
    }
    
    void downloadFile(string fileUrl, string savePath)
    {
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DoSomethingOnFinish);
        webClient.QueryString.Add("fileName", fileID.ToString());
        Uri uri = new Uri(fileUrl);
        webClient.DownloadFileAsync(uri, savePath);
        fileID++;
    }
    
    //THIS FUNCTION IS CALLED IN ANOTHER THREAD BY WebClient when download is complete
    void DoSomethingOnFinish(object sender, AsyncCompletedEventArgs e)
    {
        string myFileNameID = ((System.Net.WebClient)(sender)).QueryString["fileName"];
        Debug.Log("Done downloading file: " + myFileNameID);
    
        //Ssafety use Unity's API in another Thread with the help of UnityThread
        UnityThread.executeInUpdate(() =>
        {
            text.text = "Done downloading file: " + myFileNameID;
        });
    }
