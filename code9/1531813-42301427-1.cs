    for (int x = 1; x < NumOfPlayers; x++) {
      AddEntry(myLayout, "Player " + x.ToString());
    }
    private void AddEntry(StackLayout sl, string name) {
    
      Label label = new Label() { Text = name };
      Entry entry = new Entry() { Placeholder = name };
    
      sl.Children.Add(label);
      sl.Children.Add(entry);
    }
