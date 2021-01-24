    <asp:UpdatePanel id="upContent" runat="server">
         <ContentTemplate>
              <asp:Button id="btnCreateTextbox" runat="server" onclick="btnCreateTextbox_Click" Text="Create"></asp:Button>
              <asp:Repeater id="rpFormField" runat="server" ClientIdMode="Static">
                   <ItemTemplate>
                        <asp:Textbox id='<% Eval("Name") %>' runat="server" />
                        <asp:LinkButton id='btnDelete' runat="server" onclick='btnRemoveField_Click' CommandArguement='<% Eval(Name) %>'>Remove Field</LinkButton>
                   </ItemTemplate>
              </asp:Repeater>
         </ContentTemplate>
    </asp:UpdatePanel>
    protected void btnCreateTextbox_Click(object sender, EventArgs e)
    {
         int counter = 1;
         foreach(RepeaterItem item in rptFormField.Items)
         {
              var collection = new List<string>();
              Textbox textbox = (Textbox)item.FindControl("txtField");
              while(textbox != null)
              {
                  collection.Add(textbox.Id);
                  textbox = (Textbox)item.FindControl($"txtField-{counter}");
                  counter++;
              }
    
              collection.Add($"txtField-{counter}");
    
              rpFormField.DataSource = collection;
              rpFormField.DataBind();
         } 
    }
    protected void btnRemoveField_Click(object sender, EventArgs e)
    {
         var collection = new List<string>();
         foreach(RepeaterItem item in rptFormField.Items)
              collection.Add(item.Id);
         
         var item = ((LinkButton)e).CommandArguement;
         collection.Remove(item);
    
         rpFormField.DataSource = collection;
         rpFormField.DataBind();
    }
