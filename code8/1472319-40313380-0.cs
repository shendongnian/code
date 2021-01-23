     public ProcessStartInfo **Info** {
        **set { Info = value; }**
        get {
            Info.Arguments = args;
            Info.Arguments = Path;
            return Info;
        }
    }
