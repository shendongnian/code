    protected void PrePushUpdatesGrd_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = PrePushUpdatesGrd.SelectedRow;
        int trackingID = int.Parse(row.Cells[1].Text);
    
        using (CInTracDBEntities1 Context = new CInTracDBEntities1())
            {
                var UpdateSet = Context.Updates.FirstOrDefault(a => a.CAssetID == trackingID);
                    UpdateSet.ApproveBy = null;
                    UpdateSet.ApprovedDT = null;
                    UpdateSet.Approved = "False";
                    Context.Entry(modelItem).State= EntityState.Modified; //correct
                    Context.SaveChanges();
    
            }
    
        PrePushUpdatesGrd.DataBind();            
    }
