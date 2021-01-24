     private void DataList1_ItemCreated(object sender, System.Web.UI.WebControls.DataListItemEventArgs e) {
            if ((e.Item.ItemType == ListItemType.AlternatingItem) 
                        || (e.Item.ItemType == ListItemType.Item)) {
                DataList dtl2 = (DataList)(e.Item.FindControl("dlReplies"));
                dtl2.ItemCommand += new System.EventHandler(this.dtl2_ItemCommand);
            }
        }
        
        protected void dtl2_ItemCommand(object sender, System.Web.UI.WebControls.DataListCommandEventArgs e) {
            if (e.CommandName == "click") {
                // 'do what you want here
            }
        }
