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
            bool isValid = TryValidateModel(model, string.Format("[{0}]", i)); // or $"[{i}]" in C#6
            
        }
        return View("ImportPreview", newUsersToCreate);
    }
