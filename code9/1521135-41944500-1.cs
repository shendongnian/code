    // Build a list with items
    var items = new List<Item>();
    // For example get from database continentals.
    var gets = _connection.Continentals;
    items.Add(new Item("--- Select a continental. ---", 0));
    foreach (var get in gets)
    {
        items.Add(new Item(get.name.Length > 40 ? get.name.Substring(0, 37) + "..." : get.name, Convert.ToInt32(get.id)));
    }
    // Bind combobox list to the items
    comboBox1.DisplayMember = "Name"; // will display Name property
    comboBox1.ValueMember = "Value"; // will select Value property
    comboBox1.DataSource = item; // assign list (will populate comboBox1.Items)
    // Will select Africa
    comboBox1.SelectedValue = 3;
