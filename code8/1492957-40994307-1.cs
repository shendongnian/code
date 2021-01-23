         <ListView x:Name="lv">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="FirstName" DisplayMemberBinding="{Binding FirstName}" />
                    <GridViewColumn Header="LastName" DisplayMemberBinding="{Binding LastName}" />
                </GridView>
            </ListView.View>
        </ListView>
        public PatientList()
        {
            InitializeComponent();
            HumanResources ListAllPatients = new HumanResources();
            List<PatientInformation> AllPatients = ListAllPatients.PopPatientList();
            lv.ItemsSource = AllPatients;
        }
