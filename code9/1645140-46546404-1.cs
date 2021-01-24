    public void UpdatePopList()
    {
        CRmappings2 = new ObservableCollection<SPFetchCREntity>(crentities.ToList());
        AllCRSP = CollectionViewSource.GetDefaultView(CRmappings2);
        AllCRSP.Filter = obj =>
        {
            SPFetchCREntity entity = obj as SPFetchCREntity;
            return entity != null && entity.MU_Identifier == selectmu.ToString();
        };
    }
    private string _selectmu;
    public string Selectmu
    {
        get { return _selectmu; }
        set { _selectmu = value; AllCRSP.Refresh(); } //<-- refresh the ICollectionView whenever the selectmu property gets set or when you want to refresh the filter
    }
