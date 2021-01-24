    protected void rptPosts_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
    		Post MyPost = (Post)e.Item.FindControl("Post");
          	MyPost.UserControlButtonClicked += new EventHandler(MyPost_UserControlButtonClicked);
    	}
    }
