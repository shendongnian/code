    public List<CheckBox> GetSelectedItems()
    {
        List<CheckBox> selectedList = new List<CheckBox>();
        foreach(Control control in panelCol.Controls)  // panelCol is your panel
        {
            if(control is CheckBox)
            {
               CheckBox chkCtrl = control as CheckBox;
               if(chkCtrl.Checked)
               {
                   selectedList.Add(chkCtrl);
               }
           }
       }
       return selectedList;
    }
 
    btnValidate.MouseClick += (s, e) =>//btnValidate Event
    {
       List<CheckBox> selectedItems = GetSelectedItems();
       if(selectedItems.Count == 0)
           MessageBox.Show("Select a CheckBox!");
       else{
           // Continue with other validation for the selected checkboxes from the list
       }
      
    }
