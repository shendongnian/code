    public ActionResult Edit(string id, EMP objmodel)
        {
            if (System.Web.HttpContext.Current.Request.HttpMethod == "GET")
            {
                int j = Convert.ToInt32(id);
                EMP e =(EMP) db.EMPs.Single(n => n.id == j);
                //Either use Single(), SingleorDefault(), First(), FirstorDefault()
                return View(e);
              
            }
            else if (System.Web.HttpContext.Current.Request.HttpMethod == "POST")
            {
                if (objmodel.Name != null && objmodel.Email != null && objmodel.DOB != null)
                {
                    //db.EMPs.AddorUpdate(objmodel);//requires using System.Data.Entity.Migrations;
                    db.EMPs.Attach(objmodel);
                    db.Entry(objmodel).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.alert = u1.AlertDismissable("alert-success", "Record Updated successfully");
                    TempData["alert"] = u1.AlertDismissable("alert-success", "Record Updated successfully");
                    //return View("ShowAll", db.EMPs.ToList());
                    return RedirectToAction("index", db.EMPs.ToList());
                }
                else
                {
                    ViewBag.alert = u1.AlertDismissable("alert-danger", "No record Gets Updated , Maybe some fields are Empty");
                    TempData["alert"] = u1.AlertDismissable("alert-danger", "No record Gets Updated , Maybe some fields are Empty");
                    return View();
                }
            }
            ViewBag.alert = u1.AlertDismissable("alert-success", "Record added successfully");
            TempData["alert"] = u1.AlertDismissable("alert-success", "Record added successfully");
            //return View("ShowAll", db.EMPs.ToList());
            return RedirectToAction("index", db.EMPs.ToList());
        }
