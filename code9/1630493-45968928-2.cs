    CredentialDLL Do(Credential input)
    {
        if (input is SNMP)
        {
            return new SNMPMapper().Map(input);
        }
        else
        {
            return new HTPPMapper().Map(input);
        }
    }
