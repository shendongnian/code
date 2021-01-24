    void ClrUnwindEx(EXCEPTION_RECORD* pExceptionRecord, UINT_PTR ReturnValue, UINT_PTR TargetIP, UINT_PTR TargetFrameSp)
    {
        PVOID TargetFrame = (PVOID)TargetFrameSp;
    
        CONTEXT ctx;
        RtlUnwindEx(TargetFrame,
                    (PVOID)TargetIP,
                    pExceptionRecord,
                    (PVOID)ReturnValue, // ReturnValue
                    &ctx,
                    NULL);      // HistoryTable
    
        // doesn't return
        UNREACHABLE();
    }
