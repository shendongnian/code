    public delegate void PlayMusic();
    Dictionary<string, PlayMusic> dictOfDelegate = new Dictionary<string, PlayMusic>();
    void CreateList()
    {        
        dictOfDelegate.Add("Music 1", playmusic1);
        dictOfDelegate.Add("Music 2", playmusic2);
        ...
    }
    void InvokeMethod(string item)
    {
        PlayMusic method = dictOfDelegate.First(x => x.Key == item).Value;
        method.Invoke();
    }
