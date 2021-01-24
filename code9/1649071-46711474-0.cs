    // Populate the user variable so we can use it below to set session variables
    var user = from cbr in db.Contact_Business_Relation
               join c in db.Contact
               on cbr.Contact_No_ equals c.Company_No_ into f
               from c in f.DefaultIfEmpty()
               select new
               {
                   Mail = c.E_Mail,
                   No = c.No // Or whatever the relevant property is in c or cbr
               };
               if (user != null)
               {
                    Session["No_"] = user.No.ToString();
                    Session["Email"] = user.Mail.ToString();
                    FormsAuthentication.SetAuthCookie(user.Mail, false);
                    return RedirectToAction("Index");
               }
