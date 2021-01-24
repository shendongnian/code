    [HttpPost]
    [ActionName("TestAction")]
    public ActionResult TestAction(SQL_Blocks_App.Models.DropdownList _selectedValue)
    {
        //System.Diagnostics.Debug.WriteLine(SelectedValue);
        return RedirectToAction("Index", "[Controller]", new {@_selectedValue = _selectedValue });
    }
