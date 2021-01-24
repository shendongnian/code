    public void Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item
        || e.Item.ItemType == ListItemType.AlternatingItem)   
      {
        // I'm assuming you are using HTML img tags 
       HtmlImage proImg = e.Item.FindControl("proImg") as HtmlImage;
          proImg.Attributes.Add("style", "height:407px;");
        
      }
    }
