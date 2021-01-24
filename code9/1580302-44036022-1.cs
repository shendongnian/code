    public void MyMethod(string myValue)
    {
        try
        {
            // Test A
            if (myValue != myOtherValue)
            {
                return;
            }
            // Test B
            if (myValue != someOtherValue)
            {
                return;
            }
            DoIfTestsPass();
        }
        finally
        {
            AlwaysDoThisThing();
        }
    }
