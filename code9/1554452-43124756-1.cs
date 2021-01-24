    public ActionResult Create([Bind(Include = "Id,title,description,body")] Media media, HttpPostedFileBase file)
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                              + file.FileName);
                        media.ImagePath = file.FileName;
                    }
                    db.Medias.Add(media);
                    db.Medias.Add(media);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
    
                return View(media);
            }
