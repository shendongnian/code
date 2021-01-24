    var list = new List<SelectListItem>();
    list.Add(new SelectListItem { Selected = true, Text = stringViewOfDates[0], Value = stringViewOfDates[0]})
    for (int i = 1; i < stringView.Count(); i++)
    {
      list.Add(new SelectListItem { Selected = false, Text = stringViewOfDates[i], Value = stringViewOfDates[i]);
    }
    var selectList = new SelectList(list);
