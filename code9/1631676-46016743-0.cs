    //To calculate the percantage
    float maxProgress = assetToDownload.Count;
    for (int i = 0; i < assetToDownload.Count; i++)
    {
        UnityWebRequest www = UnityWebRequest.GetAssetBundle(assetToDownload[i], 0, 0);
        www.Send();
        
        //To remember the last progress
        float lastProgress = progress;
        while (!www.isDone)
        {
            //Calculate the current progress
            progress = lastProgress + www.downloadProgress;
            //Get a percentage
            float progressPercentage = (progress / maxProgress) * 100;
        }
    }
