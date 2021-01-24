        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffId, Tdate, Edate, Place, Organizer, Tname, Hour, Coefficient, Type, Certificate, CamMoney, CertPath, Year")] TrainingRecord trainingRecord)
        {
            if (ModelState.IsValid)
            {
                db.TrainingRecordDBSet.Add(trainingRecord);
                db.SaveChanges();
                return RedirectToAction("Search", "TrainingRecords", new { id = trainingRecord.StaffId });
            }
            ViewBag.StaffId = trainingRecord.StaffId;
            return View(trainingRecord);
        }
