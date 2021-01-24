    public MachinesWorkingTime(List<MachineWorkingTime> values)
    {        
        valuesMachine = values;
        DataContext = this; //Set viewmodel of window to this
        InitializeComponent();
    }
