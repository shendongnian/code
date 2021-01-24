     var dtOptionsData = (DataSet)ViewState["dtOption"];
            for (var i = 0; i < RptOptions.Items.Count; i++)
            {
                var tbOptionOrder = (RptOptions.Items[i].FindControl("OptionOrder") as TextBox);
                dtOptionsData.Tables[0].Rows[i]["Option Order"] = tbOptionOrder.Text;
    
                if (tbOptionOrder.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                        "alertMessage",
                        "alert('Please Enter Option Order');", true);
                    return;
                }
                if (tbOptionOrder.Text == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                        "alertMessage",
                        "alert('Please Enter Option Order');", true);
                    return;
                }
            }
    
            if (stemTextBox.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "alertMessage",
                    "alert('Please Enter a Stem');", true);
                return;
            }
    
            try
