      staffs = staffs.Where(s =>
               s.column1.CanSearchable && s.column1.Content.Contains(model.SearchString)||                                                   
               s.column2.CanSearchable && s.column2.Content.Contains(model.SearchString)|| 
               s.column3.CanSearchable && s.column3.Content.Contains(model.SearchString)||                                              
               s.column4.CanSearchable && s.column4.Content.Contains(model.SearchString));
