     if (ModelState.IsValid)
                   {
                       using (Nspira_DBContext entity = new Nspira_DBContext())
                       {
                           
                           int objid = entity.TBL_ACCESSRIGHTS.Max(p => p.ID);
                           TBL_ACCESSRIGHTS hierarchyDetail = new TBL_ACCESSRIGHTS()
                           {
                               ID = objid + 1,
                              NAME = model.NodeName,
                               PID = model.ParentName,
                           };
    
                           entity.TBL_ACCESSRIGHTS.Add(hierarchyDetail);
                           entity.SaveChanges();
                       }
                       return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                   }
               }
