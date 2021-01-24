    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="UNIDADE">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "unidade")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "sigUnidade1")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UNIDADE APOIADA">
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "unidadeApoiada")%>
                            -
                            <%# DataBinder.Eval(Container.DataItem, "sigUnidade2")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
