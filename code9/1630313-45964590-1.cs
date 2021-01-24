    protected void rptSen_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    	{
    		var sentence = (SentenceDisposition)e.Item.DataItem;
    		Repeater rptDisp = (Repeater)(e.Item.FindControl("rptDisp"));
    
    		var dispositions = SentenceDispositionAdapter.GetDispositionsBySentenceOID(sentence.SentenceID));
    		
            rptDisp.DataSource = dispositions ;
    		rptDisp.DataBind();
    	}
    }
