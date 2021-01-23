    RelsViewModel vieModel = new RelsViewModel();
    viewModel.Rels = db.Rels.ToList();
    List<classA> personsA = new List<classA>();
    List<classA> personsB = new List<classA>();
    foreach (classA item in db.Rels.ToList())
    {
        personsA.Add(item.PersonA);
        personsB.Add(item.PersonB);
    }
    // Distinct() Returns the list without duplicates
    viewModel.personsA = personsA.Distinct().ToList();
    viewModel.personsB = personsB.Distinct().ToList();
    return View(viewModel);
