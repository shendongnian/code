    class PlotAutocompleteModel
    {
      public static async Task<PlotAutocompleteModel> CreateAsync(PlotDomain plot)
      {
        ... // do asynchronous I/O to create a PlotAutocompleteModel.
      }
    }
    [HttpPost]
    public async Task<IEnumerable<PlotAutocompleteModel>> Get()
    {
      IEnumerable<PlotDomain> plots = await plotService.RetrieveAllPlots();
      var tasks = plots.Select(plot => PlotAutocompleteModel.CreateAsync(plot));
      return await Task.WhenAll(tasks);
    }
