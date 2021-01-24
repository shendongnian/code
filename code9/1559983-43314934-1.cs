    protected void rptNewsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                    
                Panel pnlTopImage = e.Item.FindControl("PanelTopImage") as Panel;
                Panel pnlBottomImage = e.Item.FindControl("PanelBottomImage") as Panel;
                
                if (e.Item.ItemIndex % 2 == 0)
                {
    
                    pnlTopImage.Visible = true;
                    pnlBottomImage.Visible = false;
                }
                else
                {
                    pnlTopImage.Visible = false;
                    pnlBottomImage.Visible = true;
                }
            }
    
           
        }
