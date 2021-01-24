    List<Holiday> duplicates = new List<Holiday>();
    for (int i = 0; i < list.Count; i++)
        for (int j = i + 1; j < list.Count; j++)
        {
             if (IsDuplicate(list[i], list[j]))
             {
                  duplicates.Add(list[i]);
                  duplicates.Add(list[j]);
                  break;
             }
        }
