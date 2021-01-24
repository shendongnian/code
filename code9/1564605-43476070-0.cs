    tableLayoutPanel1.Controls.Add(new CheckBox(), 0, 0);
    tableLayoutPanel1.Controls.Add(new CheckBox(), 0, 1);
    tableLayoutPanel1.Controls.Add(new CheckBox(), 0, 2);
    tableLayoutPanel1.Controls.Add(new CheckBox(), 0, 3);
    tableLayoutPanel1.Controls.Add(new CheckBox(), 0, 4);
    // Option 1
    // Enumerate controls in order of height (from first to last on the form)
    foreach (var checkBox in tableLayoutPanel1.Controls.OfType<CheckBox>().OrderBy(c => c.Location.Y))
    {
        // ...
    }
    // Option 2
    // Enumerate controls based on what row they are in the tabletLayoutPanel
    foreach (var checkBox in tableLayoutPanel1.Controls.OfType<CheckBox>().OrderBy(c => tableLayoutPanel1.GetRow(c)))
    {
        // ...
    }
