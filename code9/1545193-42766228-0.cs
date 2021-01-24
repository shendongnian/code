    public FSC(string CPS, FSCServerLocator fscLoc)
    {
        if (string.IsNullOrWhiteSpace(CPS))
        {
            //parameter filtering 
            // other process here if any 
            cps = CPS;
            throw new Exception("No vin provided at initialization");
        }
    }
