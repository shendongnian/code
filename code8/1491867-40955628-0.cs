    public async Task<IActionResult> Index()
    {
        var vm = new ViewModel();
        try
        {
            var max = 0;
    
            if (_dbContext.OnlyTable.Any())
            {
                max = _dbContext.OnlyTable.Max(x => x.SomeColumn);
            }
    
            _dbContext.Add(new TestTable() { SomeColumn = max + 1 });
            _dbContext.SaveChanges();
    
            await MakePostCallAsync("http:\\google.com", vm);
    
            if (!string.IsNullOrEmpty(vm.TextToDisplay))
            {
                vm.TextToDisplay = "I have inserted the value " + newmax + " into table (-1 means error)";
            }
            else
            {
                vm.TextToDisplay = "Errored!";
            }
    
    
        }
        catch (Exception ex)
        {
            vm.TextToDisplay = "I encountered error message - \"" + ex.Message + "\"";
        }
        return View("Index", vm);
    }
    
    private async Task MakePostCallAsync(string url, ViewModel vm)
    {
        var httpClient = new HttpClient();
    
        var httpResponse = await httpClient.PostAsync("http://google.com", null).ConfigureAwait(true);
    
        newmax = _dbContext.OnlyTable.Max(x => x.SomeColumn);
    }
