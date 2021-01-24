    DataTable dt=(someDS.someDT)dgSomeGrid.DataSource
    bool r;
    if (dt.AsEnumerable().Any(x => x.HasVersion(DataRowVersion.Original)))
    {
        r = dt.AsEnumerable().Any(x => x["Column1", DataRowVersion.Original].ToString()==someCode);
    }
    else
    {
        r = dt.AsEnumerable().Any(x => x["Column1"].ToString()==someCode);
    }
    
