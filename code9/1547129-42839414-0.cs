    int id;
    var phonesData = new List<SelectListItem>();
    if (Int32.TryParse(carrierid, out id))
    {
        var phonesList = this.GetPhones(id, emailaddress); // here
        phonesData = phonesList.Select(m => new SelectListItem()
        {
            Text = m.Name,
            Value = m.PhoneID.ToString(),
        }).ToList();
        return Json(phonesData, JsonRequestBehavior.AllowGet);
    }
    else
       return null; // or throw an exception
