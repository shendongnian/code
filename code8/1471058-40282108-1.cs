    public JsonResult AutoCompleteCustomer(string term)
        {
            var data = db.Customers.Where(s => term== null || s.Name.ToLower().Contains(term.ToLower())).Select(x => new { id = x.CustomerID, value = x.CustomerName }).Take(20).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
