    var selectedProcessList = processList
                              .TakeWhile(x => !x.Name.ToLower().Equals("process-4"))
                              .ToList();
    // Include selected item
    if (selectedProcessList.Length < processList.Length)
        selectedProcessList.Add(processList
                                .SkipWhile(x => !x.Name.ToLower().Equals("process-4"))
                                .First());
