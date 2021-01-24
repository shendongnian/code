        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BidstonHwrc bidstonhwrc)
        {
            _context.BidstonHwrc.Add(bidstonhwrc);
            try
            {
                _context.SaveChanges(); //either all changes are made or none at all
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            int id = bidstonhwrc.Id;
            Session["ItemID"] = id;
            return View();
        }
