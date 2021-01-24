    public enum PlatformType {Normal, Ice, Fire, etc}; //Use public only if needed, of course
    
    interface IPlatform {
        PlatformType platformType { get; }
        //Your other stuff here
    }
