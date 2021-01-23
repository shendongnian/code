    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      ComboBox box = e.Control as ComboBox;
      if (box != null)
      {
        box.AutoCompleteSource = AutoCompleteSource.ListItems;
        box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        box.DataSource = _dropDownItems;
      }
    }
