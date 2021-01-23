    protected void TFSListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
      ListViewDataItem myitem = (ListViewDataItem)e.Item; 
    
      if (e.Item.ItemType == ListViewItemType.DataItem) 
      {
        Control divDetails = e.Item.FindControl("divLsvDetails");
        WorkItem myWI = myitem.DataItem as WorkItem;
    
        if (myWI != null && divDetails != null)
        {          
          if (myWI.Fields.Contains("Symptom"))
          {            
            ((HtmlGenericControl)divDetails).InnerHtml = myWI["Symptom"].ToString();
          }
        }
      }
    }
