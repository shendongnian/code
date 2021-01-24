     public string VERSION = null;
     void LoadVersion()
    {
    #if UNITY_ANDROID
    string full_path = string.Format("{0}/version", Application.streamingAssetsPath);
    string jsonString;
    // Android only use WWW to read file
    WWW reader = new WWW(full_path);
    while (!reader.isDone) { }
    jsonString = reader.text;
    #else
    string path = string.Format("{0}/version", Application.streamingAssetsPath);
    StreamReader reader = new StreamReader(path);
    VERSION = reader.ReadToEnd().Trim();
    reader.Close();
    #endif
    }
