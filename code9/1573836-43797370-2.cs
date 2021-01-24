     public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                fad_Data fad_Data = db.fad_Data.Find(id);
                fad_Data?.sizeList = fad_Data?.size?.Split(',').ToList().Select(s => new SelectListItem() { Text = s, Value = s }).ToList(); // You need to add ToList() at the end.
                if (fad_Data.sizeList == null)
                {
                    return HttpNotFound();
                }
                return View(fad_Data);
            }
