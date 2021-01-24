    if(e.Item.ItemType ==ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
      System.Web.UI.HtmlControls.HtmlImage imageControl =(System.Web.UI.HtmlControls.HtmlImage) e.Item.FindControl("imageControl");
                if (((DataRowView)e.Item.DataItem)["imagedata"] != DBNull.Value)
                {
                    imageControl.Src = "data:image/png;base64,"+ Convert.ToBase64String((byte[])((DataRowView)e.Item.DataItem)["imagedata"]) ;
                }
    }
