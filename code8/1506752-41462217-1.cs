    try
    {
        testObj.methodThrowingExceptionX();
        testObj.anotherMethodThrowingExceptionX();
    }
    catch (X xExceptionObj)
    {
        MethodBase site = xExceptionObj.TargetSite;
        
        switch (site.Name)
        {
            case nameof(testObj.methodThrowingExceptionX):
                return blah....
            case nameof(testObj.anotherMethodThrowingExceptionX):
                return blub....
            default:
                throw new Exception("Unexpected method caused exception: " + site.Name);
        }
    }
