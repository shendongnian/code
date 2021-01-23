    //_tempSales = new SalesHelper();
    ICacheData<Sale> _cacheSale = new Sale();
    //_tempSales.SetCache(_cacheSale);
    //_tempSales.GetAllData();
    SalesHelper.Instance.SetCache(_cacheSale);
    SalesHelper.Instance.GetAllData(); //Now it should return the into
    _service = new ServiceHost(typeof(CacheDataService));
