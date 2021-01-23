    public JsonResult FindCustomer(string value)
    {
        var result = new SelectList(db.Customers.Where(t =>
            t.GetType().GetProperties().Any(x => 
            (x is string)&&((string)x).Equals(value))),
            "ID", "PersonalMail");
        return Json(jj);
    }
