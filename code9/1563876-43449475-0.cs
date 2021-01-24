                int[] eliminateDays = null;
                // wrap enum values into collection
                var enumDaysCollection = (from m in Enum.GetNames(typeof(DayofWeekType))
                                          select new
                                          {
                                              Text = m.ToString(),
                                              Value = (int)Enum.Parse(typeof(DayofWeekType), m)
                                          }).ToList();
                // array contain days (enum values) which will be ignored as per user specific
                // lets say you want to ignore monday, tuesday, wednesday, thursday 
                if (User.IsInRole("SomeUserRole"))
                {
                    eliminateDays = new[] { 1, 2, 3, 4 };
                }
                else if (User.IsInRole("AnotherUserRole"))
                {
                    eliminateDays = new int[] { 1, 3 };
                }
                else
                {
                    //For Admin will make empty so that it will show all days
                    eliminateDays = new int[] { };
                }
                // filter collection
                var dropDownItems = (from day in enumDaysCollection
                                     let days = eliminateDays
                                     where !days.Contains(day.Value)
                                     select new SelectListItem
                                     {
                                         Text = day.Text,
                                         Value = Convert.ToString(day.Value)
                                     }).ToList();
                //send dropdownlist values to view
                ViewBag.DropDownItems = dropDownItems; 
