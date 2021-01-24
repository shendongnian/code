    public async Task<ActionResult> Index()
    {
          var someImportantData = await httpClient.ReadAsStringAsync().ConfigureAwait(false); 
          return View( new MyViewModel(someImportantData)); // This line will not be called until previous line is completed.
    }
