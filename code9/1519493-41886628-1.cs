    public override void InitializeEditingControl(int rowIndex, object 
        initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        YourEditingControl c = DataGridView.EditingControl as YourEditingControl;
        //Set c.Properties here
    }
