    public IActionResult Names()
    {
      var names = GetDataContext().People.Select(p => p.Name).ToList();
      return View(new NameListModel{Names = names});
    }
