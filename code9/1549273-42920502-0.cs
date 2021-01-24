    private void yourCombobox_SelectedValueChanged(object sender, EventArgs e){
        int selectedComboboxId = yourCombobox.SelectedValue;
        bool recordExists = _context.Set<YourEntity>().Any(x=>x.Id = selectedComboboxId);
        if(recordExists){
            //record is in the table
            //your code
        }
        else 
        {
            //record is not in the table
            MessageBox.Show("Record does not exist. Select new option.")
        }
    }
