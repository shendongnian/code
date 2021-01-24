    var newList = "1,2,3,4,5,6,7,8,9,0,12,14,16,17,192,222,66,44,22,11".Split(',')
        .Select(n => int.Parse(n))
        .ToList();
    Console.WriteLine( 
       string.Join(",", newList.
            SortBigger_K_InFrontAnscendingThenAddSmallerEqual_K_Ascending(70)));
    Console.ReadLine();
