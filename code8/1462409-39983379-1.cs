        List<CheckBox> boxesList = new List<CheckBox>();
        //The named Grid, and not TabControl
        var children = LogicalTreeHelper.GetChildren(gridChk); 
        
        //Loop through each child
        foreach (var item in children)
        {
            var chkCast = item as CheckBox;
            //Check if the CheckBox object is checked
            if (chkCast.IsChecked == true)
            {
                boxesList.Add(chkCast);
            }
        }
