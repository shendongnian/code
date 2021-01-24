           public JsonResult LoadPhonesByCarrierId(string carrierid, string emailaddress)
           {
            string pattern = @"^([a-zA-Z0-9._%+-]{1,50})(@gmail|GMAIL)(\.)(com|COM)$";
            Match match = Regex.Match(emailaddress, pattern);//checks the email address from user and pattern.
            if (match.Success)//if true it will do the following
            {
                          var gov = from g in db.Phones
                          where g.GovAllowed == true
                          select g;
            }
            else
            {
                          var com = from c in db.Phones
                          where c.CommerceAllowed == true
                          select c;
            }
        var phonesList = this.GetPhones(Convert.ToInt32(carrierid));
        var phonesData = phonesList.Select(m => new SelectListItem()
        {
            Text = m.Name,
            Value = m.PhoneID.ToString(),
        });
        return Json(phonesData, JsonRequestBehavior.AllowGet);
    }
