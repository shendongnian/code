    public virtual ActionResult  getListOfSuppliers(int? supplier_no)
    {
        using (db)
        {
            var model = new ViewModel
            {
               Name = <name value>,
               InventoryNo = <name value>,
               Suppliers = db.vendors.Select(c => new SelectListItem
               {
                  Value = c.supplier_no,
                  Text = c.name
               }).ToList()
            };
            return View(model);
        }
    }
