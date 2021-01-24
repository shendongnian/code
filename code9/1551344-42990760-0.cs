             var listA = (new[] { "apple", "mango", "grapes", "pineapple", "banana"    }).ToList();
             var listB = (new[] { "mango", "grapes", "watermelon", "orange" }).ToList();
           
             var listCheckboxItem = (from a in listA
                                    join b in listB on a equals b into lst
                                    from item in lst.DefaultIfEmpty()
                                    select new { Name = a, IsChecked = !(string.IsNullOrEmpty(item)) }
                        ).ToList();
