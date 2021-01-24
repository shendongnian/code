    [HttpPost]
    public ActionResult Create(OrderViewModel order)
    {
        var bothFieldsAreEmpty = string.IsNullOrEmpty(order.Field1) && string.IsNullOrEmpty(order.Field2);
        var bothFieldsAreFilled = !string.IsNullOrEmpty(order.Field1) && !string.IsNullOrEmpty(order.Field2);
        
        if (bothFieldsAreEmpty || bothFieldsAreFilled)
        {
            ModelState.AddModelError("", "Please select either Field1 or Field2, not both.");
        }
        if (ModelState.IsValid)
        {
        // Do something
        }
        return View(order);
    }
