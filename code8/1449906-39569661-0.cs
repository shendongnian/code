    int Count = 1;
    Part1Result p1 = null;
    foreach (DateTime Date in TestDate)
    {
        if(Count == 1 or Count == 25){
            p1 = Part_1_code();
            Count = 1;
        }
         //Part_2_code
         //use variable p1 here - its the results from Part1Code
         Count++;                
    }
