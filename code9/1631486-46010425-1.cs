        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReferralId,CompanyId")] Referral referral)
        {
            if (ModelState.IsValid)
            {
                if (referral.CompanyId == 4)
                {
                    var f = new Company() { Name = DateTime.Now.ToString() };
                    referral.Company = f;
                }
                db.Referrals.Add(referral);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", referral.CompanyId);
            return View(referral);
        }
