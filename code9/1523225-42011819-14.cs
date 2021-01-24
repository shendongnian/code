    public void DoStuff<T>(T whatever)
           where T : IWhatever
    {
    }
    
    // versus
    
    public void DoStuff(IWhatever whatever)
    {
    }
