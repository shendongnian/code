    public ActionResult Edit(int? id)
    {
        if (!id.HasValue)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
