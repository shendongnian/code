    public JsonResult Customer(int? id)
        {
            var user = User.Identity.Name;
            if (!AccountController.IsInRole(user, "admin"))
            {
                return null;
            }
            id = id == null ? 0 : id;
            var customer = db.PrmCustomers
                .Where(x => x.EmailAddress != null && x.CustomerID > id)
                .OrderBy(x => x.CustomerID).ToList()  //  <-- ToList executes the query
                .Select(x => new CustomerDTO()
                {
                    email = x.EmailAddress,
                    phone = x.MobilePhoneNumber,
                    username = "",
                    first_name = x.Name,
                    last_name = x.Surname,
                    gender = x.GenderType,
                    customer_code = x.CustomerID,
                    is_active = "",
                    date_joined = x.CreateDate.ToString("d/M/yyyy HH:mm:ss"),
                    //date_joined = x.CreateDate,
                    last_login = "",
                    //date_of_birth = x.BirthDate,
                    date_of_birth = x.BirthDate.ToString("d/M/yyyy HH:mm:ss"),
                    password = x.Password,
                    email_allowed = x.IsNewsletter,
                    sms_allowed = x.IsSms,
                    verified = x.IsApprovedEmail,
                    social_account_facebook_uuid = "",
                    social_account_facebook_extra = ""
                });
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
