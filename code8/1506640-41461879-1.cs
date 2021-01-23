    if (String.IsNullOrWhiteSpace(filter_param))
    {
        SelectJobComboBox.DataSource = arrProjectList;  //assign original list of directories
    }
    SelectJobComboBox.IntegralHeight = true;
    SelectJobComboBox.DroppedDown = true;
