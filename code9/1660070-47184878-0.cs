    IRunningObjectTable rot;
    GetRunningObjectTable(0, out rot);
    IEnumMoniker monikerEnumerator;
    rot.EnumRunning(out monikerEnumerator);
    IntPtr pNumFetched = new IntPtr();
    IMoniker[] monikers = new IMoniker[1];
    while (monikerEnumerator.Next(1, monikers, pNumFetched) == 0)
    {
        IBindCtx bindCtx;
        CreateBindCtx(0, out bindCtx);
        string displayName;
        monikers[0].GetDisplayName(bindCtx, null, out displayName);
        // Console.WriteLine(displayName);
    }
