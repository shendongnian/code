        protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        	Image img = e.Item.FindControl("brandImage") as Image;
        	img.ImageUrl = "../Images/Guitar Brands/" +
                ((DataRowView)e.Item.DataItem).Row["image"];
        }
