    var eventSendingCheckbox = sender as CheckBox
    if( eventSendingCheckbox.Name == "cb(ALL)" )
    {
        foreach( Control cbStatus in customComboBox4.DropDownControl.Controls )
        {
             if( cbStatus != eventSendingCheckbox )
             {
                 cbStatus.Checked = eventSendingCheckbox.Checked;
             }
        }
    }
