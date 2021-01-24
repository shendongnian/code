    // divCheckBoxes is a container like div or panel
    List<string> pageItemsList = new List<string>(30); // Developer approximate number
    foreach (var ctrl in divCheckBoxes.Controls)
    {
    	CheckBox chk = ctrl as CheckBox;
    	if(chk == null) { continue; }
    	if(chk.Attributes["CustomAttribute"] != "CustomValue") { continue; }
    	if (chk.Checked) { dataList.Add(chk.Attributes["CustomValueAttribute"]); }
    }
