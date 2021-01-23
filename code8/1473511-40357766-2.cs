    public JsonResult FindCustomer(string value)
    {
        var result = new SelectList(db.Customers.Where(t =>
            t.GetType().GetProperties().Any(x => 
                (x.PropertyType==typeof(string)) && x.GetValue(value))),
            "ID", "PersonalMail");
        return Json(jj);
    }
