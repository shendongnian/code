    public Form1()
        {
            
            InitializeComponent();
            DdState.Items.Clear();
            DdState.DataSource = UsStates;
            DdState.DisplayMember = "Statename";
            DdState.SelectedIndex = 0;
        }
        private List<IStateItem> UsStates
        {
            get
            {
                List<IStateItem> usStates = new List<IStateItem>();
                usStates.Add(new IStateItem("California","status1"));
                usStates.Add(new IStateItem("Ohio", "status3"));
                return usStates;
            }
        }
        private class IStateItem
        {
            public IStateItem(string statename, string stateStatus)
            {
                Statename = statename;
                StateStatus = stateStatus;
            }
            public string Statename { get; set; }
            public string StateStatus { get; set; }
        }
