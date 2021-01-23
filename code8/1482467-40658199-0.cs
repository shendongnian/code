    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include="SalesMemberID,FirstName,LastName,PageName,CellPhone,Email,InactiveRedirectTo,CustomText,Photo,Active, Position")] SalesMember salesmember, HttpPostedFileBase file)
    {
            salesmember = db.SalesMembers.Find(salesmember.SalesMemberID);
            salesmember.Photo = saveImage(file, salesmember, SalesPhoto);
            salesmember.UpdateDate = DateTime.Now;
            salesmember.IPAddress = Request.UserHostAddress;
            salesmember.AddUser = "admin";
            salesmember.UpdateUser = "admin";
            db.Entry(salesmember).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        
            return View(salesmember);
    }
