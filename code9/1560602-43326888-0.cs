    public dynamic ViewBag
    {
        get
        {
            if (_dynamicViewDataDictionary == null)
            {
                _dynamicViewDataDictionary = new DynamicViewDataDictionary(() => ViewData);
            }
            return _dynamicViewDataDictionary;
        }
    }
