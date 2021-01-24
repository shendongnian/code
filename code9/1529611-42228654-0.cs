    [Flags]
    public enum Status
    { 
        Nominal      = 0,  // in bits: ... 0000 0000
        Modified     = 1,  //              0000 0001
        DirOneOnly   = 2,  //              0000 0010
        DirTwoOnly   = 3,  //              0000 0011 **common bit with Modified state **
        DirOneNewest = 4,
        DirTwoNewest = 5,
