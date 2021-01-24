    [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                      
                var review = rr.Single(r => r.Id == id);
                if (TryUpdateModel(review))
                {
                    return RedirectToAction("Index");
                }
                return View(review);
           }
