    [HttpGet]
    public ActionResult Create()
    {
        List<DeptCode> _depts = new List<DeptCode>();
        _depts.Add(new DeptCode { Id = 0, Description = "IT"});
        _depts.Add(new DeptCode { Id = 1, Description = "Customer Services" });
        _depts.Add(new DeptCode { Id = 2, Description = "Warehouse" });
        var _listSelectItem = _depts.Select(@group => new SelectListItem
        {
            Selected = true,
            Text = @group.Description,
            Value = @group.Id.ToString()
        }).ToList();
        var firstOrDefault = _listSelectItem.FirstOrDefault();
        if(firstOrDefault != null)
        {
            ViewBag.DeptList = new SelectList(_listSelectItem, "Value", "Text", firstOrDefault.Text);
        }
        return View();
    }
