    List<string> arrProjectList;
    public ReconciliationReport()
    {
        InitializeComponent();
        AppDomain.CurrentDomain.AssemblyResolve += FindDLL;
        this.sRootDirectory = Properties.Resources.sRootDirectory;
        arrProjectList = Directory.GetDirectories(sRootDirectory).Select(Directory => Path.GetFileName(Directory)).ToList();
        arrProjectList.Sort();
        // then just bind it to the DataSource of the ComboBox
        SelectJobDropdown.DataSource = arrProjectList;
        // don't select automatically the first item
        SelectJobDropdown.SelectedIndex = -1;
    }
