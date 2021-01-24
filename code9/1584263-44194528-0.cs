    private void LoadCache()
    {
        _sharedList = new TestPnrHeaderResponse();
        _sharedList.PnrLegs = new List<PnrLegVM>();
        _sharedList.listInt = new List<int>();
        List<int> listInt = _sharedList.listInt;
        Task.Factory.StartNew(() =>
        {
            listInt.AddRange(GetIntList());
        });
    }
