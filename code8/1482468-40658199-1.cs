     [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include="SalesMemberID,FirstName,LastName,PageName,CellPhone,Email,InactiveRedirectTo,CustomText,Photo,Active, Position")] SalesMember salesmember, HttpPostedFileBase file)
    {
        SalesMember SalesPhoto = db.SalesMembers.AsNoTracking().Find(salesmember.SalesMemberID);
        salesmember.Photo = saveImage(file, salesmember, SalesPhoto);
        if (ModelState.IsValid)
        {
            salesmember.AddDate = SalesPhoto.AddDate;
            salesmember.UpdateDate = DateTime.Now;
            salesmember.IPAddress = Request.UserHostAddress;
            salesmember.AddUser = "admin";
            salesmember.UpdateUser = "admin";
            db.Entry(salesmember).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(salesmember);
    }
