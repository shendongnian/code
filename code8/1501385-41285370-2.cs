        DropDownComboBoxColumn col = _dataGridView.Columns[_dataGridView.CurrentCell.ColumnIndex] as DropDownComboBoxColumn;
        if (col == null)
        {
          throw new InvalidCastException("Must be in a DropDownComboBoxColumn");
        }
        DropDownStyle = col.DropDownStyle;
        // (If you don't explicitly set the Text then the current value is
        // always replaced with one from the drop-down list when edit begins.)
        Text = _dataGridView.CurrentCell.Value as string;
        SelectAll();
