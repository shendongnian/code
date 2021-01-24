    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Upload(HttpPostedFileBase csvFile)
    {
        // var csvRecords = do stuff to retrieve data from CSV file
        var newUsersToCreate = new List<UserViewModel>();
        for (int i = 0; i < csvRecords.Count; i++)
        {
            UserViewModel model = new UserViewModel
            {
                Name = csvRecords[i].Name,
                ....
            };
            newUsersToCreate.Add(model);
            // validate the model and include the collection indexer
            bool isValid = ValidateModel(model, i));   
        }
        return View("ImportPreview", newUsersToCreate);
    }
    private bool ValidateModel(object model, int index) 
    { 
        var validationResults = new List<ValidationResult>(); 
        var context = new ValidationContext(model); 
        if (!Validator.TryValidateObject(model, context, validationResults, true)) 
        { 
            foreach (var error in validationResults) 
            { 
                string propertyName = $"[{index}].{error.MemberNames.First()}"; 
                ModelState.AddModelError(propertyName, error.ErrorMessage); 
            } 
            return false; 
        } 
        return true; 
    }
