    //old code
    Random contestantPicker = new Random();
    HashSet<int> fighters = new HashSet<int>();
    while (fighters.Count < 16) // Run Random until 16 fighters have been picked
    {
    	fighters.Add(contestantPicker.Next(0, listBoxRegistered.Items.Count));
    }
    //list to hold fighter names
    List<string> fightersList = new List<string>();
    
    //iterate through all indexes in hashset
    for (int i = 0; i < fighters.Count; i++)
    {
    	//show in output window
    	Diagnostics.Debug.WriteLine("figther number {0}, named: {1}", i + 1, listBoxRegistered.GetItemText(listBoxRegistered.Items[i]));
        //add fighters to list...
        fightersList.Add(listBoxRegistered.GetItemText(listBoxRegistered.Items[i]));
    }
    //... and show it in some message box
    MessageBox.Show(string.Join(", ", fightersList.ToArray()));
