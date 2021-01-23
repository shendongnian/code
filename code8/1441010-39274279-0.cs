        int selRowIndex = ((GridViewRow)(((DropDownList )sender).Parent.Parent)).RowIndex;
             usercontrols_asp_formctl_dropdownlist aspDrop = (usercontrols_asp_formctl_dropdownlist)grdviewCurrentSystems.Rows[selRowIndex].FindControl("aspdropSystemStatus");
                usercontrols_asp_formctl_textbox aspTxt = (usercontrols_asp_formctl_textbox)grdviewCurrentSystems.Rows[selRowIndex].FindControl("txtSystemStatusInfo");
     if (aspDrop.SelectedValue == "")
            {
                valid = false;
            }
            else if (aspDrop.SelectedValue != "1" && string.IsNullOrEmpty(aspTxt.Text))
            {
                valid = false;
            }
            e.IsValid = valid;
