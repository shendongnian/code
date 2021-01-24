    [HttpPost]
    public ActionResult Create(PostModel post)
    {
        if (!ModelState.IsValid)
        {
            return View(post);
        }
        foreach (var file in files)
        {
            if (file.ContentLength > 0)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Img/") + file.FileName);
                // Initialize a new ImageModel, set its properties and add it to the PostModel
                ImageModel image = new ImageModel()
                {
                    ImagePath = file.FileName
                };
                post.Images.Add(image);
            }
        }
        repository.Save(post);
        return RedirectToAction("display");
    }
