    public Action GetSkills()
    {
        var skills = "Android App, Android"; // Data from DB
        var model = new ViewModel
        {
            Skills = skills.Split(',').ToList(),
        }
        return View(model);
    }
