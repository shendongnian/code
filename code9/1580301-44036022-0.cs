    public void MyMethod(string myValue)
    {
        try
        {
            // Test A
            if (myValue != myOtherValue)
            {
                DoMyOneThing();
                return;
            }
            // Test B
            if (myValue != someOtherValue)
            {
                DoMyOneThing();
                return;
            }
        }
        finally
        {
            DoImportantThings();
        }
    }
