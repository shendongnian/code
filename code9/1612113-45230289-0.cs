    List<string> ListItems = new List<string>();
    foreach (var el_loopVariable in shipments.Items)
    {
        //Passing id "chk" to FindControl method of current ListViewItem and trying to cast it as Checkbox
        var checkBox = el_loopVariable.FindControl("chk") as CheckBox;
        if (checkBox != null && checkBox.Checked)
        {
            ListItems.Add(checkBox.ToolTip);
        }
    }
