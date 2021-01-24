    //Logic to handle allowing the user to click the checkbox, but have everywhere else respond to normal listbox logic.
    private void _lstReceivers_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Visual curControl = _lstReceivers as Visual;
        ListBoxItem testItem = null;
        //Allow normal selection logic to take place if the user is holding shift or ctrl
        if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl) || Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            return;
        //Find the control which the user clicked on. We require the relevant ListBoxItem too, so we can't use VisualTreeHelper.HitTest (Or it wouldn't be much use)
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(curControl); i++)
        {
            var testControl = (Visual)VisualTreeHelper.GetChild(curControl, i);
            var rect = VisualTreeHelper.GetDescendantBounds(testControl);
            var pos = e.GetPosition((IInputElement)curControl) - VisualTreeHelper.GetOffset(testControl);
            if (!rect.Contains(pos))
                continue;
            else
            {
                //There are multiple ListBoxItems in the tree we walk. Only take the first - and use it to remember the IsSelected property.
                if (testItem == null && testControl is ListBoxItem)
                    testItem = testControl as ListBoxItem;
                //If we hit a checkbox, handle it here
                if (testControl is CheckBox)
                {
                    //If the user has hit the checkbox of an unselected item, then only change the item they have hit.
                    if (!testItem.IsSelected)
                        dontChangeChecks++;
                    ((CheckBox)testControl).IsChecked = !((CheckBox)testControl).IsChecked;
                    //If the user has hit the checkbox of a selected item, ensure that the entire selection is maintained (prevent normal selection logic).
                    if (testItem.IsSelected)
                        e.Handled = true;
                    else
                        dontChangeChecks--;
                    return;
                }
                //Like recursion, but cheaper:
                curControl = testControl;
                i = -1;
            }
        }
    }
    //Guard variable
    int dontChangeChecks = 0;
    //Logic to have all selected listbox items change at the same time
    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
        if (dontChangeChecks > 0)
            return;
        var newVal = ((CheckBox)sender).IsChecked;
        dontChangeChecks++;
        try
        {
            //This could be improved by making it more generic.
            foreach (CheckableItem<Receiver> item in _lstReceivers.SelectedItems)
            {
                item.IsChecked = newVal.Value;
            }
        }
        finally
        {
            dontChangeChecks--;
        }
    }
