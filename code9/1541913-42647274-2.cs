    void Awake()
    {
        UnityThread.initUnityThread();
    }
    
    void looper()
    {
        medialogic();
        EasyTimer.SetInterval(() =>
        {
            if (i == arrLength - 1)
            {
                info = dir.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
                arrLength = info.Length;
                i = 0;
            }
            else
            {
                i++;
            }
    
            UnityThread.executeInUpdate(() =>
            {
                medialogic();
            });
        }, interval);
    }
