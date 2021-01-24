    var allLists = new[] { list1, list2, list3 };
    var final = allLists.SelectMany(list => list)
                        .GroupBy(result => new { result.EmpId, result.EmpName })
                        .Select(group => new Results
                        { 
                            EmpId = group.Key.EmpId, 
                            EmpName = group.Key.EmpName, 
                            Rating = group.Sum(result => result.Rating) 
                        });
