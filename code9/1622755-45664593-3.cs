    void TxtName_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
    {
        //These lines are used to get the position of the control that was clicked
        var obj = sender as CheckBox;
        var row = obj?.Parent as View; 
        var parent = row?.Parent as ListView;
        if (parent == null)
        {
            return;
        }
        var position = parent.GetPositionForView(row);
        // Once you have the position you can get the item and change
        // its IsSelected
        var item = _list[position];
        item.IsSelected = e.IsChecked;
    }
