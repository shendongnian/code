    public static bool IsCallFinal()
    {
        var currentStack = new StackTrace();
        return false == currentStack.GetFrames()
                  .Any(x => x.GetMethod().Name == "<GetPreviewOperationsAsync>b__0");
    }
