    if ((e.Item.ItemType == ListItemType.Item) ||
                       (e.Item.ItemType == ListItemType.AlternatingItem))
    {
        var edit_Score = (Label)e.Item.FindControl("edit_Score");
        var txtIsComplete = (Label)e.Item.FindControl("txtIsComplete");
        if (edit_Score.Text == "Keyboarding")
        {
            if (txtIsComplete.Text == "Complete")
            {
                txtIsComplete.Text = "Pass";
            }
            else if(txtIsComplete.Text == "InComplete")
            {
                txtIsComplete.Text = "Fail";
            }
        }
    }
