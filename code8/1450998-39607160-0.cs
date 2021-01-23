     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="cbIsActive" runat="server" 
                      Text='<%# Eval("IsActive") == DBNull.Value ? false : Convert.ToBoolean(Eval("IsActive"))%>'>
        </asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
