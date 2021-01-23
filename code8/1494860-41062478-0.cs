    // Nothing entered e.g. "  "
    if (string.IsNullOrWhiteSpace(txtInsert.Text)) {
      MessageBox.Show("Oops! Please enter a number to add to the list");
    
      return;    
    }
    
    int value;
    
    // Invalid value entered (e.g. "bla-bla-bla")
    if (!int.TryParse(txtInsert, out value)) {
      MessageBox.Show("Oops! Invalid number");
    
      return;
    }
    
    // Value is out of [0..100] range
    if ((value < 0) || (value > 100)) {
      MessageBox.Show($"Oops! {value} is out of [0..100] range");
    
      return;
    }
    
    // Duplicates
    if (lstNumberList.Items.Contains("\t" + value.ToString())) {
      MessageBox.Show($"Oops! {value} is a duplicate number");
    
      return;
    }
    ...
    // All tests are passed, let's add the value
    lstNumberList.Items.Add("\t" + value.ToString());
