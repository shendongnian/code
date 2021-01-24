    namespace X.Views
    {
        public partial class FAQ : System.Web.UI.Page
        {
    
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
            public void lvp(object sender, ListViewItemEventArgs e)
            {
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {                   
                    Label content = (Label)e.Item.FindControl("positionContent");
                    System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
    
    
                        content.Text = "Hello";
    
                }
            }
    }
             
