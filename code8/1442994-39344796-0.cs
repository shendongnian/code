     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="Name" /> 
                                    <asp:BoundField DataField="Detail" HeaderText="Detail" />
                                    <asp:BoundField DataField="other" HeaderText="other" />
        
                                    <asp:TemplateField >
                                        <ItemTemplate>
                                          <asp:Button ID="buttonReject" Text="Reject" runat="server"   />
                                        </ItemTemplate>
                                        
                                        <ItemStyle HorizontalAlign="Right" />
                                        
                                    </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
