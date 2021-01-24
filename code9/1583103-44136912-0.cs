        var value = DropDownList1.SelectedValue;
        DropDownList1.DataBind();
        if (value == "Professional")
        {
            DropDownList2.Items.Insert(0, new ListItem("Please Select One", "Please Select One"));
            DropDownList2.Items.Insert(1, new ListItem("Continuing - Professional", "Continuing - Professional"));
            DropDownList2.Items.Insert(2, new ListItem("Fixed Term", "Fixed Term"));
            DropDownList2.Items.Insert(3, new ListItem("Casual", "Casual"));
        }
        else if (value == "Academic")
        {
            DropDownList2.Items.Insert(0, new ListItem("Please Select One", "Please Select One"));
            DropDownList2.Items.Insert(1, new ListItem("Continuing - Academic", "Continuing - Academic"));
            DropDownList2.Items.Insert(2, new ListItem("Fixed Term", "Fixed Term"));
            DropDownList2.Items.Insert(3, new ListItem("Sessional", "Sessional"));
        }
    }
