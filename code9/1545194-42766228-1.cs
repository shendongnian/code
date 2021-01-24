    public FSC(string CPS, FSCServerLocator fscLoc)
    {
        if (string.IsNullOrWhiteSpace(CPS))
        {
            //parameter filtering 
            throw new Exception("No vin provided at initialization");
        }
        // other process here if any 
        cps = CPS;
    }
