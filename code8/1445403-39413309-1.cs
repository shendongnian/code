    #if DEBUG
    struct DebuggingAid
    {
        public string A;
        public string B;
        public string C;
    }
    #endif
    #if DEBUG
    public void f()
    {
        var aid = new DebuggingAid { A = "TestValue1", B = "TestValue2" };
        // var real data
        MethodBeingDebuggedWithStubDebuggingAidData(aid.A, A.B);
    }
    #endif
