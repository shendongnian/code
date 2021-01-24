    <asp:GridView  ID="OracleView" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="OracleView_RowDataBound">
                                      <Columns>
                                              <asp:BoundField HeaderText="L id" DataField="id"></asp:BoundField>
                                              <asp:TemplateField HeaderText="Concern">
                                                  <ItemTemplate>
                                                      <asp:DropDownList ID="ConcernList" runat="server" AutoPostBack="true" ></asp:DropDownList>
                                                  </ItemTemplate>
                                              </asp:TemplateField>
                                             
                                      </Columns>
                                </asp:GridView>
