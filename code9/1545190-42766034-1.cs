    public FSC(string CPS, FSCServerLocator fscLoc)
    {
        if (string.IsNullOrWhiteSpace(CPS))
        {
            // the exception is being thrown here.
            throw new Exception("No vin provided at initialization");
            // any code below will not be reached.
            // closing the bracket before the following statement fixes the "unreachable" code issue.
            cps = CPS;
        }
    }
