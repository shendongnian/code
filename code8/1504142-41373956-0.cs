    foreach (System.Web.UI.WebControls.ListItem item in chbList_Risks.Items)
             {
                            if (item .Selected == true)
                            {
                                value = item .Text;
            
                                if (value == "ABC")
                                {
                                   ddlRiskLevel.SelectedValue = "2";
                                }
                            }
                            else
                            {
                                value = item .Text;
            
                                if (value == "XYZ")
                                {
                                     ddlRiskLevel.ClearSelection();
                                }
                            }
            }
