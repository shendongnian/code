    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            var model = new MediaViewModel();
            model.Foo.Add(new Models.Media
            {
                body = "test body",
                description = "description",
                ImagePath = "../path/path",
                title = "this title"
            });
            return View(model);            
        }
