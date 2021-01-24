    public Task<IActionResult> Names()
    {
      var names = await GetDataContext().People.Select(p => p.Name).ToListAsync();
      return View(new NameListModel{Names = names});
    }
