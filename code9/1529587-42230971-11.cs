            [ValidateAntiForgeryToken]
            public ActionResult GetPersons([DataSourceRequest] DataSourceRequest dsRequest)
            {
                var result = persons.ToDataSourceResult(dsRequest);
                return Json(result);
            }
    
            [ValidateAntiForgeryToken]
            public ActionResult UpdatePerson([DataSourceRequest] DataSourceRequest dsRequest, Person person)
            {
                if (person != null && ModelState.IsValid)
                {
                    var toUpdate = persons.FirstOrDefault(p => p.PersonID == person.PersonID);
                    TryUpdateModel(toUpdate);
                }
    
    
                return Json(ModelState.ToDataSourceResult());
            }
