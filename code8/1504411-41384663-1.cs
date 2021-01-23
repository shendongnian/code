    private void OpenFileExecute(string file)
    {
        IRunningObjectTable ir;
        // get all OLE/COM Automation servers
        GetRunningObjectTable(0, out ir);
        if (ir != null)
        {
            IEnumMoniker moniker;
            // Get an enumerator to iterate over them
            ir.EnumRunning(out moniker);
            if (moniker != null)
            {
                moniker.Reset();
                IMoniker[] results = new IMoniker[1];
                // iterate
                while (moniker.Next(1, results, IntPtr.Zero) == 0)
                {
                    // we need a Bind Context
                    IBindCtx bindCtx;
                    CreateBindCtx(0, out bindCtx);
                    // what is the name of the OLE/COM Server
                    string objName;
                    results[0].GetDisplayName(bindCtx, null, out objName);
                    // what have we got ...
                    Trace.WriteLine(objName);
                    // I test with VS2010 instances, 
                    // but feel free to get rid of the .10
                    if (objName.StartsWith("!VisualStudio.DTE.10"))
                    {
                        object dteObj; //
                        ir.GetObject(results[0], out dteObj);
                        // now we have an OLE automation interface 
                        // to the correct instance
                        DTE dteTry = (DTE)dteObj;
                        // determine if this is indeed
                        // the one you need
                        // my naive approach is to check if
                        // there is a Document loaded
                        if (dteTry.Documents.Count == 1)
                        {
                            dteTry.ExecuteCommand(
                                "File.OpenFile",
                                String.Format("\"{0}\"", file));
                        }
                    }
                    bindCtx.ReleaseBoundObjects();
                }
            }
        }
    }
            
    [DllImport("ole32.dll")]
    public static extern int GetRunningObjectTable(int reserved,
                                out IRunningObjectTable prot);
    
    [DllImport("ole32.dll")]
    public static extern int CreateBindCtx(int reserved,
                                    out IBindCtx ppbc);
