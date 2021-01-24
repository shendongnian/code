    public override void InitializeEditingControl(int rowIndex, object
        initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        // Set the value of the editing control to the current cell value.
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        AutoCompleteEditingControl ctl = DataGridView.EditingControl as AutoCompleteEditingControl;
        ctl.AutoCompleteList = this.AutoCompleteList;
        // Use the default row value when Value property is null.
        if (this.Value == null)
        {
            ctl.Text = (string)this.DefaultNewRowValue;
        }
        else
        {
            ctl.Text = (string)this.GetValue(rowIndex);  // this line can't use this.Value
        }
    }
