     [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Page page)
        {
            Page.db.Database.ExecuteSqlCommand("INSERT into Customer(Name, Email, PhoneNumber, Address, Quantity) VALUES(@Name, @Email, @PhoneNumber, @Address, @Quantity)",
                new SqlParameter("@Name",page.customer.Name),
                new SqlParameter("@Email", page.customer.Email),
                new SqlParameter("@PhoneNumber", page.customer.PhoneNumber),
                new SqlParameter("@Address", page.customer.Address),
                new SqlParameter("@Quantity", page.customer.Quantity)
                );
            Page.db.SaveChanges();
            return View();
        }
