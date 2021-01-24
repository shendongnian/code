    public ActionResult Edit(string StaffID)
    {
    var query = from s in db.tblStaffAssessment
                            where (s.StaffID.Equals(StaffID))
                            select s;
    
                var currentAssessments = new List<AssessmentAddView>();
    
                foreach (var s in query)
                {
    
                    currentAssessments.Add(new AssessmentAddView()
                    {
                        Id = s.Id,
                        Data = new SelectList(db.tblAssessment.OrderBy(a => a.AssessmentName), "Id", "AssessmentName"),
                        SelectedId = s.AssessmentID
                });
                }
    
                return View(currentAssessments);
    }    
    
    public ActionResult Edit(IEnumerable<AssessmentAddView> assessments)
            {
                if (ModelState.IsValid)
                {
                    foreach (AssessmentAddView item in assessments)
                    {
                        //perform edit action
                    }
    
                    return RedirectToAction("Index", "MyController");
                }
                return RedirectToAction("Index", "MyController");
            }
    
    public ActionResult AddNewAssessment()
                {
                    var model = new AssessmentAddView
                    {
                        Data = new SelectList(db.tblAssessment.OrderBy(a => a.AssessmentName), "Id", "AssessmentName")
                    };
                    return PartialView("_Assessment", model);//return your partial view here
                }
        
    public ActionResult DeleteAssessment(string Id)
                {
                    // do delete action with id
                    return RedirectToAction("Index", "MyController");
                }
