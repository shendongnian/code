    <body>
        <form id="form1" runat="server">
        <div>
       <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridview"
                                               >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="name" runat="server" Text='<%#Eval("Name")%>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Roll No">
                                                <ItemTemplate>
                                                    <asp:Label ID="rollno" runat="server" Text='<%#Eval("Roll_No")%>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Gender">
                                                <ItemTemplate>
                                                   <asp:CheckBox runat="server" Text='<%#Eval("Gender")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    </Columns>
           </asp:GridView>
        </div>
        </form>
    </body>
