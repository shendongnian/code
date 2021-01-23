    ViewBag.YearsList = Enumerable.Range(2000, 15)
        .Select(g => new SelectListItem 
        { 
            Value = g.ToString(),
            Text = g.ToString(),
            Selected = (g == currentlySelectedIndex)
        }).ToList();
