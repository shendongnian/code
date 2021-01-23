       protected void ddlStatus_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (strMode == "M")
            {
                var disable = (from ListItem item in ddlStatus.Items.OfType<ListItem>()
                    where item.Selected
                    where item.Value == "30"
                    select int.Parse(item.Value)).Any();
                 if (disable)
                {
                    GridExpInfo.AllowUserToAddRows  = false;
                }
                else
                {
                    GridExpInfo.AllowUserToAddRows = true;
                }
            }
        }
