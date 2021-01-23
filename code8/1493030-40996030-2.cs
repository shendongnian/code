    public PatientList()
    {
        InitializeComponent();
        ListAllPatients = new HumanResources();
        AllPatients = ListAllPatients.PopPatientList();
        this.Usernames = new string[AllPatients.Count];
        
        int i = 0;
        foreach (PatientInformation PatientChoice in AllPatients)
        {
            Usernames[i] = PatientChoice.Username;
            lboxPatients.Items.Add(string.Format("{0} {1}; {2}", PatientChoice.FirstName, PatientChoice.LastName, PatientChoice.Gender));
            i += 1;
        }
    }
