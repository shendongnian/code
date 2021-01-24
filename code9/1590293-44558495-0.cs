    protected override void OnAppearing()
    {
        PopulateMachineSelectionList();
        base.OnAppearing();
    }
    async void PopulateMachineSelectionList()
    { 
        loadedMachines = await machineSync.GetMachines();
        if (loadedMachines.Count() != 0)
        {
            machineSelectionList.Clear();
            foreach (Machine mach in loadedMachines)
            { //I have an archive boolean that determines whether or not machines should be shown
                if (!mach.archived)
                {
                    Console.WriteLine("Adding: " + mach.name + " to the list template");
                    machineSelectionList.Add(new ListTemplate(null, mach.name, true, true));
                }
            }
            Console.WriteLine("Refresh List");
            Device.BeginInvokeOnMainThread(() =>
            {
                machineList.ItemsSource = null;
                machineList.ItemsSource = new List(machineSelectionList);
            });
        }
        machineList.SelectedItem = null;
    }
