    public ActionResult Create()
    {
        TeamMemberVM model = new TeamMemberVM();
        ConfigureViewModel(model);
        // For an Edit method, your would set the existing selected items here
        model.SelectedDanGrades = ...
        return View(model);
    }
    public ActionResult Create(TeamMemberVM model)
    {
        if (!ModelState.IsValid)
        {
            ConfigureViewModel(model); // repopulate the SelectList
            return View(model);
        }
        // model.SelectedDanGrades contains the ID's of the selected options
        // Initialize an instance of your data model, set its properties based on the view model
        // Save and redirect
    }
    private void ConfigureViewModel(TeamMemberVM model)
    {
        IEnumerable<DanGrade> danGrades = db.DanGrades();
        model.DanGradesList = danGrades.Select(x => new SelectListItem
        {
            Value = x.DanGradeId.ToString(),
            Text = x.??? // the name of the property you want to use for the display text
        });
    }
