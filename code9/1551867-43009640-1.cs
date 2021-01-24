    var dataGridImageSources = new List<Uri>();
    
    for (int i = 0; i < Initial_Lvl; i++)
    {
        dataGridImageSources.Add(new Uri(filePaths[i], 
            UriKind.RelativeOrAbsolute));
    }
    string[] names = {"apple", "orange", "banana"};
    foreach (var name in names)
    {
        dataGridImageSources.Add(new Uri(string.Format("{0}.jpg", name), 
            UriKind.RelativeOrAbsolute));
    }
    // Now you have a list of Uris that you can assign to
    // different DataGridObjectOpt object ListSource properties
    // This example just creates a bunch of them and assigns the property
    var dataGridOptions = new List<DataGridObjectOpt>();
    foreach (var dataGridImageSource in dataGridImageSources)
    {
        dataGridOptions.Add(new DataGridObjectOpt {ImageSource = dataGridImageSource});
    }
