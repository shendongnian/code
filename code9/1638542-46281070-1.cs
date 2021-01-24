    public ActionResult Search(FilterViewModel model)
    {
        var filter = new FilterModel
        {
            Person = new FilterPersonModel
            {
                Name = model.Name,
                Age = model.Age
            },
            Job = new FilterJobModel
            {
                CompanyName = model.CompanyName,
                JobTitle = model.JobTitle
            }
        };
        // do whatever with `filter`
    }
