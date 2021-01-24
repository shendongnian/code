    bool isDebugging;
    #if DEBUG
        isDebugging = true;
    #else
        isDebugging = false;
    #endif
    if(isDebugging)
    {
        e.Handled = false;
    }
    else
    {
        ShowUnhandledException(e);
    }
