    public ActionResult Add(Contact c)
            {
                bool Status = false;
                string message = "";
                if (ModelState.IsValid)
                {
                    c.Date = DateTime;
                    db.Contact.Add(c);
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    message = "Invalid Request";
                }
                ViewBag.Message = message;
                ViewBag.Status = Status;
                return View(c);
            }
