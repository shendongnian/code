    public void searchMUID()
    {
        string Mupass = "";
        AllCRSP.Filter = obj =>
        {
            SPFetchCREntity entity = obj as SPFetchCREntity;
            return obj != null && entity.SW_Version == SearchMU.ToString() && entity.MU_Identifier == Mupass.ToString();
        };
        AllCRSP.Refresh();
    }
