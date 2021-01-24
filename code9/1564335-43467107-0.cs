    List<string> list1 = new List<string> { "P1", "P2", "P3" };
    List<string> list2 = new List<string> { "Q1", "Q2", "Q3" };
    List<string> list3 = new List<string> { "R1", "R2", "R3" };
    List<string> combinedList = new List<string>();
    for(int i = 0; i < list1.Count; i++)
    {
        combinedList.Add(list1[i]);
        combinedList.Add(list2[i]);
        combinedList.Add(list3[i]);
    }
