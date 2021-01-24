       var enumlist =  Enum.GetValues(typeof(DayofWeekType)).Cast<DayofWeekType>().Select(v => new SelectListItem
        {
            Text = v.ToString(),
            Value = ((int)v).ToString()
        });
    
        if (IsUser) //your condition here
        {
          enumlist=  enumlist.Skip(4);
    
        }
      
        ViewBag.enumlist = enumlist;
