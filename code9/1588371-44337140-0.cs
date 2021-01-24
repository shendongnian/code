    public enum Versions
    {
       One = 1, 
       Two = 2, 
       Three = 3
    }
    
    public void Do()
    {
       Versions version = (Version)-9;
       // version is now Versions.One.
       // Its value however is -9, what kind of version should -9 be?
    }
