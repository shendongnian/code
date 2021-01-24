    var selected = new List<int>();
    for (int i = 0 i < model.Count; i++)
    {
        if (selected.Contains(model[i].YourProperty))
        {
            ModelState.AddModelError("", "Please make a unique selection");
            break;
        }
        else
        {
            selected.Add(model[i].YourProperty);
        }
    }
    if (!ModelState.IsValid)
    {
        return View(model);
    }
    ....
