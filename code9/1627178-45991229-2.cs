    public void MethodThatFailsSometimes()
    {
        try {
            PerformFailingOperation();
        } 
        catch (Exception e) when (e.LogAndBeCaught())
        {
        }
    }
