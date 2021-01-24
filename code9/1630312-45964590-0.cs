    protected void rptChg_ItemDataBound(object sender, RepeaterItemEventArgs e)
    	{
           //check if it is a ItemTemplate. Sometimes could be a header template?
    	   if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	   {
    		 var charge = (Charge)e.Item.DataItem;
    		 Repeater rptSen = (Repeater)(e.Item.FindControl("rptSen"));
    		 
    		var sentences = SentenceAdapter.GetByChargeObjectID(chg.ChargeObjectID); // notice I removed the namespace for clarity, use the using statements instead
    		
    		rptSen.DataSource = sentences;
    		rptSen.DataBind();
    	  }
    	}
