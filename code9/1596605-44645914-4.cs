    private ObservableCollection<ProjectInformation> projectInformationList1 = new ObservableCollection<ProjectInformation>();
    foreach (DtoProjectsRow row in projectsTable.Rows)
    {
        projectInformationList1.Add(new ProjectInformation(row));
    }
    lstbxindex.DataContext = projectInformationList1;
