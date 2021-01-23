     public ActionResult Browse(string category)
            {
                Leeoriyas.Models.Category categoryModel = storeDB.Category.Include("ArtS").Single(c => c.Name == category);
                    return View(categoryModel);
            }
