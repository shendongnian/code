    var asmCode = new CpuIdAssemblyCode();
    CpuIdInfo info = new CpuIdInfo();
    asmCode.Call(0, ref info);
    asmCode.Dispose();
    string ret= info.GetString();
