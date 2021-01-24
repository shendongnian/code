        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DOB,Male,Female,Address,City,ZIP,PhoneHome,PhoneCell,Email,EmergencyContact,EmergencyContactPhone,EmergencyContactRelationship,ReferredBy,Allergy,AllergyDescription,HighBloodPressure,LowBloodPressure,HeartCondition,Diabetes,Anemia,HighCholesterol,Pacemaker,Epilepsy,Pregnant,Cancer,STD,Pain,PainDescription,Headache,HeadacheDescription,CommonCold,HighBloodPressureConcern,Stress,Depression,Sleep,Menstruation,Fertility,WeightControl,Other")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                subject.DateCreated = DateTime.Now; //if you want UTC time, use DateTime.UtcNow
                db.SubjectDatabase.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(subject);
        }
