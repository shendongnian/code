    public JsonResult FindCustomer(string value)
    {
        var result = new SelectList(db.Customers.Where(t =>
            t?.GetType().GetProperties().Any(x => //for all columns of a row where...
                (x.PropertyType==typeof(string)) && // it does have the same type
                x.GetValue(t, null) != null && // the value should not be null
                x.GetValue(t, null).Equals(value)) // the value should be equal
            ?? false), // if t is null, than skip it
            "ID", "PersonalMail");
        return Json(jj);
    }
