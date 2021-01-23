    Public void AddButton()
    {
    //Add button
    DataGridViewButtonColumn EditButton = new DataGridViewButtonColumn();
    EditButton.UseColumnTextForButtonValue = true;
    EditButton.DataPropertyName = "btnColumn";
    EditButton.Text = "Button Text";
    DataGridView_name.Columns.Add(EditButton);
    }
