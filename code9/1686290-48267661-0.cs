    public void ReadJson(){
            string path = Application.streamingAssetsPath + "/elements.json";
            #if UNITY_EDITOR
            path = "/StreamingAssets/elements.json";
            #endif
            WWW www = new WWW(path);
            while(!www.isDone) {}
            string json = www.text;
            itemsContent = JsonUtility.FromJson<Main> (json); 
            bundleForPing = itemsContent.bundleID;
        }
