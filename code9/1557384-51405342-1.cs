    public virtual MachineKeyDataProtector Create(params string[] purposes)
    {
        return new MachineKeyDataProtector(purposes);
    }
    
    public virtual DataProtectionProviderDelegate ToOwinFunction()
    {
        return purposes =>
        {
            MachineKeyDataProtector dataProtecter = Create(purposes);
            return new DataProtectionTuple(dataProtecter.Protect, dataProtecter.Unprotect);
        };
    }
