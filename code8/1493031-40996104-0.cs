    HumanResources ListAllPatients;
    List<PatientInformation> AllPatients;
    List<string> Usernames = new List<string>();
    public PatientList()
    {
        InitializeComponent();
        ListAllPatients = new HumanResources();
        AllPatients = ListAllPatients.PopPatientList();
        foreach (PatientInformation PatientChoice in AllPatients)
        {
            Usernames.Add(PatientChoice.Username);
            lboxPatients.Items.Add(string.Format("{0} {1}; {2}", PatientChoice.FirstName, PatientChoice.LastName, PatientChoice.Gender));
        }
    }
