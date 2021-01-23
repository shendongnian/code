    public enum MyEnum
    {
        Nothing = 0,
        Run = 1,
        Jump = 2,
        Stand = 4,
        Go = 8,
        RunJump = 3,
        RunStand = 5
    }
    
    public MyEnum GetValue(bool go, bool stand, bool jump, bool run)
    {
        // true, true, true, true is 1111
        // true, true, true, false is 1110
        var returnValue = (go ? 1 << 3 : 0) + (stand ? 1 << 2 : 0) + (jump ? 1 << 1 : 0) + (run ? 1 : 0);
    
        return (MyEnum)returnValue;
    }
