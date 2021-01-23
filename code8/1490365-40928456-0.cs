        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Panel replypic = (Panel)e.Item.FindControl("replypic");
            Panel replywrite = (Panel)e.Item.FindControl("replywrite");
            if (e.CommandName == "img_Click") // check command is cmd_delete
            {
                // get you required value
                string CustomerID = (e.CommandArgument).ToString();
                replypic.Visible = true;
                replywrite.Visible = true;
            }
        }
    }
