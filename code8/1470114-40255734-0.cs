    private DataTable _dtCriterias;
 
    public DataTable DtCriterias {
        get { return _dtCriterias; }
        set
        {
            _dtCriterias = value;
            Notify(() => DtCriterias);
        }
    }
