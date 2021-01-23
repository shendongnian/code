    <asp:TemplateField>
      <ItemTemplate>
        <asp:Button ID="btnRedirect" runat="server" 
          CommandName="CompleteTransaction" 
    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
          Text="Complete Transaction" />
      </ItemTemplate> 
    </asp:TemplateField>
 
    Page previousPage = Page.PreviousPage;
        if (previousPage != null && previousPage.IsCrossPagePostBack)
        {
            lblName.ServiceType = ((Label)previousPage.FindControl("lblServiceType")).Text;
            lblEmail.Method= ((Label)previousPage.FindControl("lblMethod")).Text;
        }
