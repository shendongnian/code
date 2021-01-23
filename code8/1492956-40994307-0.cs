        public PatientList()
        {
            InitializeComponent();
            HumanResources ListAllPatients = new HumanResources();
            List<PatientInformation> AllPatients = ListAllPatients.PopPatientList();
            foreach (PatientInformation PatientChoice in AllPatients)
            {
                lboxPatients.Items.Add(string.Format("{0};{1}", PatientChoice.FirstName, PatientChoice.LastName));
            }
        }
