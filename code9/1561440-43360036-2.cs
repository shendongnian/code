    protected void yourcheckboxlistname_SelectedIndexChanged(object sender, EventArgs e)
    {
        string value = string.Empty;
    
        string result = Request.Form["__EVENTTARGET"];
    
        string[] checkedBox = result.Split('$'); ;
    
        int index = int.Parse(checkedBox[checkedBox.Length - 1]);
    
        if (yourcheckboxlistname.Items[index].Selected)
        {
            value = yourcheckboxlistname.Items[index].Value;
        }
        else
        {
    
        }
       // For getting the list of values that are selected u can get it like  
        //this
        int lastSelectedIndex = 0;
      string lastSelectedValue = string.Empty;
    foreach (ListItem listitem in yourcheckboxlistname.Items)
    {
        if (listitem.Selected)
        {
            int thisIndex = yourcheckboxlistname.Items.IndexOf(listitem);
            if (lastSelectedIndex < thisIndex)
            {
                lastSelectedIndex = thisIndex;
                lastSelectedValue = listitem.Value;
            }
        }
     }
    }
