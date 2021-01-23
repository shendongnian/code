    <asp:DataGrid ID="grid1" runat="server" AutoGenerateColumns="false" EnableViewState="true" CssClass="GridviewControlStyle" CellSpacing="0" CellPadding="4" HeaderStyle-CssClass="HeaderStyle"
    OnEditCommand="grid1_EditCommand" OnUpdateCommand="grid1_UpdateCommand" OnCancelCommand="grid1_CancelCommand" OnItemDataBound="grid1d_ItemDataBound">
    <Columns>
        <asp:TemplateColumn>
            <HeaderTemplate>
                <strong>Status</strong>
            </HeaderTemplate>
            <ItemTemplate>
                <%# DataBinder.Eval(Container, "DataItem.STATUS") %>
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <HeaderTemplate>
                <strong>Amount</strong>
            </HeaderTemplate>
            <ItemTemplate>
                <%# DataBinder.Eval(Container, "DataItem.AMT") %>
            </ItemTemplate>
         <EditItemTemplate>
                <asp:TextBox ID="txtAmount" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AMT") %>' CssClass="small" ReadOnly="false"/>
            </EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn>
            <ItemTemplate>
                <asp:Button runat="server" Text="Edit" ID="btnEdit" Visible='<%# IsRowEditable(Eval("STATUS").ToString()) %>' CommandName="Edit" />
             </ItemTemplate>
            <EditItemTemplate>
                <asp:Button runat="server" Text="Update" ID="btnUpdate"  CommandName="Update" />
                <asp:Button runat="server" Text="Cancel" ID="btnCancel"  CommandName="Cancel" />
           </EditItemTemplate>
        </asp:TemplateColumn>
        </Columns>
