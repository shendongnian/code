    public ActionResult NewStudentFeeStatus()
            {
                ViewBag.DeparmentList = db.tblDepartments.ToList();
                List<tblStdEnrollment> enrollmentList = (from p in db.tblStdDetails
                                                         join e in db.tblStdEnrollments on p.ID equals e.Stdref_id
                                                         select e).ToList();
                return View(enrollmentList);
            }
    
