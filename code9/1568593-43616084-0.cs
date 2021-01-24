    public InstallationStep this[string s]
    {
        get
        {
            return DictSteps[s];
        }
        set
        {
            DictSteps[s] = value;
        }
    }
