    // Button adding a new object to the list
    private void btnNewDisplay_Click(object sender, EventArgs e)
    {
        DisplayDefinition d = new DisplayDefinition();
        d.Name = "SomeName";
        displaydefinitions.Add(d);
        listDisplays.SelectedIndex = -1;
        listDisplays.SelectedItem = d;
    }
    private void listDisplays_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listDisplays.SelectedIndex == -1) return;
        DisplayDefinition d = (DisplayDefinition)listDisplays.SelectedItem;
        // Do something with "d" ...
        Console.WriteLine(d.Name);
    }
