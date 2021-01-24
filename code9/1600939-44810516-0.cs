    int[] order = Enumerable.Range(0, peopleArray.Length)
                            .OrderBy(i => peopleArray[i].Score)
                            .GroupBy(i => peopleArray[i].Group)
                            .SelectMany(g => g).ToArray();          // { 2, 1, 3, 0, 4 }
    Array.Sort(order, peopleArray); 
    Debug.Print(string.Join(", ", peopleArray.Select(p => p.ArrayIndex)));  // "3, 1, 0, 2, 4"
