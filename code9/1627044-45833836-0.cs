    private void cboVender_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e) {
         if ((e.Item.ItemType == ListItemType.Item)) {
             rowIndex = e.Item.ItemIndex;
              // here you have your row number, you can Access the value of that column and do whatever you want
         }         
     }
