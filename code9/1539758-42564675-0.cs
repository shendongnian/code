    try something like this
    
         void ProductsGridView_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        // If multiple buttons are used in a GridView control, use the
        // CommandName property to determine which button was clicked.
        if(e.CommandName=="Add")
        {
          // Convert the row index stored in the CommandArgument
          // property to an Integer.
          int index = Convert.ToInt32(e.CommandArgument);
    
          // Retrieve the row that contains the button clicked 
          // by the user from the Rows collection.
          GridViewRow row = ProductsGridView.Rows[index];
    
          // Create a new ListItem object for the product in the row.     
          ListItem item = new ListItem();
          item.Text = Server.HtmlDecode(row.Cells[1].Text);
    
          // If the product is not already in the ListBox, add the ListItem 
          // object to the Items collection of the ListBox control. 
          if (!ProductsListBox.Items.Contains(item))
          {
            ProductsListBox.Items.Add(item);
          }
        }
      }
        
        <asp:GridView ID="ProductsGridView" 
                      DataSourceID="ProductsDataSource"
                      AllowPaging="true" 
                      AutoGenerateColumns="false"
                      OnRowCommand="ProductsGridView_RowCommand"
                      OnRowCreated="ProductsGridView_RowCreated"  
                      runat="server">
                      <Columns>
                        <asp:TemplateField>
                          <ItemTemplate>
                            <asp:LinkButton runat="server"
                              ID="AddButton"
                              CommandName="Add"
                              Text="Add" />
                          </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" 
                          HeaderText="Product Name"/> 
                        <asp:BoundField DataField="ProductNumber" 
                          HeaderText="Product Number"/>
                      </Columns>
        
                    </asp:GridView>
