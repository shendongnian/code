         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbIsActive" runat="server" 
                          Text='<%# Eval("IsActive") == DBNull.Value ? false : Convert.ToBoolean(Eval("IsActive"))%>'>
            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                   <%-- Checkbox List To binding to sqldatasourc--%>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1"
            DataTextField="IsMultiRole" DataValueField="IsMultiRole">
        </asp:CheckBoxList>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView> 
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WaltonCrmConnectionString %>"
            SelectCommand="select top 10 IsMultiRole from Users"></asp:SqlDataSource>
