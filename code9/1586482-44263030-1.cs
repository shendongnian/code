    protected void rptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
          DataRowView MyRow = (DataRowView)e.Item.DataItem;
          Post MyPost = (Post)e.Item.FindControl("Post");
          MyPost.LoadPost(MyRow);
        }
    }
