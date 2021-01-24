    [HTTPGET]
    public async Task<IActionResult> Name(string id) {
      ViewModel model = new ViewModel();
      var name = await GetNameFromBYId(id);
    
      model.Name = name; // Right code
    
    }
