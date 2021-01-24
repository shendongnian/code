    private bool _handle = true;
    public void SaveMasterData(StaffMasterData nwRowData)
    {
        using (var db = CreateDbContext())
        {
            //MasterDataBinding is the observableCollection
            //the datagrid is being bound to.
            var staffNoExists = MasterDataBinding.Any(p => p.StaffNo == nwRowData.StaffNo);
            if (!staffNoExists)
            {
                db.StaffMasterDatas.AddOrUpdate(nwRowData);
                db.SaveChanges();
            }
            else
            {
                Alerts.Error("Staff Number exists");
                _handle = false;
                nwRowData.StaffNo = null;
                _handle = true;
            }
        }
    }
    public void propertyChanged_Event(object sender, PropertyChangedEventArgs e)
    {
        if (!_handle && sender is StaffMasterData)
        {
            SaveMasterData((StaffMasterData)sender);
        }
    }
