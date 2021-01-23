    <asp:DataList ... OnItemDataBound="Item_Bound"  runat="server">
    </asp:DataList>
    void Item_Bound(Object sender, DataListItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item || 
          e.Item.ItemType == ListItemType.AlternatingItem)
       {
          Label lefthowmanylabel =(Label)e.Item.FindControl("Lefthowmanylabel");
          Label quantitylabel = (Label)e.Item.FindControl("quantitylabel");
    
          if (int.Parse(quantitylabel.Text) < 11)
          {
              lefthowmanylabel.Visible = true;
          }
          else
          {
             lefthowmanylabel.Visible = false;
          }
       }
    }
