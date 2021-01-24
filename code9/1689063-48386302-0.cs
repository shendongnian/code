    public ClassOne() {
        ID = 22;
    }
    ClassOne OriginalClass = new ClassOne();
    var LocalID = OriginalClass.ID; // 22 again!
