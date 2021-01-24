    protected override void OnInit(EventArgs e)
    {
           base.OnInit(e);
           Repeater1.ItemDataBound += (s, ev) =>
           {
               if (ev.Item.ItemType != ListItemType.AlternatingItem && ev.Item.ItemType != ListItemType.Item)
                        return;
                 var btnTest= ((System.Web.UI.WebControls.Button) ev.Item.FindControl("btnTEST"));
                 btnTest.Enabled = Session["USER_ID"] != null;
            };
     }
