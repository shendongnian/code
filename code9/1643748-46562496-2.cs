    public ActionResult applyingjobs()
        {
            var c = Repository.SelectAll().ToList();
            if (c.Count() > 0)
            {
                return RedirectToAction("Create");
            }
            else
            {
                TempData["value"] = "No Records";
                return RedirectToAction("Create");
            }
        }
