            if (ModelState.IsValid)
            {
                db.Entry(emailTemplateViewModel.EmailTemplate).State = EntityState.Modified;
                if (emailTemplateViewModel.EmailAccountId > 0)
                {
                    emailTemplateViewModel.EmailTemplate.EmailAccount = db.EmailAccounts.Find(emailTemplateViewModel.EmailAccountId);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emailTemplateViewModel);
