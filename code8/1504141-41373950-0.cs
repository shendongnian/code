    foreach (ListItem item in chbList_Risks.Items)
       {
           if (item.Selected)
           {
            ddlRiskLevel.SelectedValue = "2";
            break;
           }
           else
          {
           ddlRiskLevel.ClearSelection();
          }
       }
