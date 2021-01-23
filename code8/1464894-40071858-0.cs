    [HttpPost]
    public ActionResult Create(CreateStudent student)        
    { 
         var genderList = new List<SelectListItem>()
         {
              new SelectListItem { Text = Constants.Gender.Boy, Value = Constants.Gender.Boy}, 
              new SelectListItem { Text = Constants.Gender.Girl, Value = Constants.Gender.Girl},
         };
         
         if (ModelState.IsValid)
         {
            var result = _student.Insert(mappedStudent);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                student.Genders = genderList;
                TempData["Message"] = "Failed to create new student";
                return View(student);
            }
         }
         //Model validation fails. Return the same view
         student.Genders = genderList;
         return View(student);
        }
    }
