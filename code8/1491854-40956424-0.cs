        [HttpPost]
        public ActionResult Create(Assignment assignment,HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file.ContentLength > 0) {
                         MemoryStream target = new MemoryStream();
                         file.InputStream.CopyTo(target);
                         byte[] data = target.ToArray();
                         assignment.File = data
                    }
                    context.Assignments.Add(assignment);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(assignment);
            }
            catch (Exception e)
            {
                return View();
            }
        }
