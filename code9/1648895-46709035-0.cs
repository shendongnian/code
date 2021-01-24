     [HttpPost]
        public ActionResult CustomerMenu(FormCollection Fq)
        {
            string mail = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name.Split('|')[0];
            var usr = _customer.GetUserByEmail(mail);
            List<CustomerMenu> custmenulist = new List<Models.CustomerMenu>();
            foreach (var key in Fq.Keys)
            {
                if(Fq["Date"]!= Fq[key.ToString()])
                {
                    var dd = Fq["Date"];
                    var value = Fq[key.ToString()];
                    CustomerMenu custmenu = new Models.CustomerMenu();
                    custmenu.CustMenu_ItemID = Convert.ToInt64(value);
                    custmenu.CustMenu_CustID = usr.CustID;
                    custmenu.CustMenuDate =Convert.ToDateTime(dd);
                    custmenu.CustMenu_EnteredOn = DateTime.Now;
                    _customermenu.Add(custmenu);
                }
            }
            return View();
        }
