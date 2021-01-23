    foreach (var file in files)
    {
        File.Move(File.FullName, ConvertToUnsign(file.Fullame.ToLower().
                                 Replace("'", String.Empty).Replace("-", String.Empty)));
        lstNames.Add(file.Name.Replace(".jpg", String.Empty));
    }
    return lstNames;
