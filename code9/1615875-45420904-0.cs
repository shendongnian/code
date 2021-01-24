    public async Task GetStocks()
    {
      var stockings = new List<Services.Models.Admin.SiteStockingLevelsModel>();
      IsBusy = true;
      cts?.Cancel();
      cts = new CancellationTokenSource();
      var token = cts.Token;
      await Task.Run(() => { CreateStockingCollection(token); });
      ValidateMaterials();
      IsBusy = false;
    }
    private void CreateStockingCollection(CancellationToken token)
    {
      var stockings = _siteStockingLevelsService.GetSiteInventoryLevels(SiteId, token);
      CreateStockingLevelCompareCollection(stockings);
      StockingLevels =
          _mapper.Map<TrulyObservableCollection<SiteStockingLevelsModel>>(stockings);            
      ((INotifyPropertyChanged)StockingLevels).PropertyChanged +=
          (x, y) => CompareStockingChanges();
      CompareStockingChanges();
    }
