       <asp:Repeater ID="Repeaterp" runat="server" DataSourceID="XmlDataSource1">
            <HeaderTemplate>
                <table>
                    <%--------Your Master Table--------%>
                    <tr>
                        <th>usedcount
                        </th>
                        <th>notUsedCount
                        </th>
                    </tr>
                    <tr>
                        <td>Row1 Cell1</td>
                        <td>Row1 Cell2</td>
                    </tr>
                    <tr>
                        <td>
                            <%----------------First Inner Table------------------%>
                            <asp:Table ID="Table1" runat="server">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>
                            Header
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                            Header
                                    </asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                            <%---Add your conents as properties----%>
                                     <%= this.ContentString %>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>                         
                                        content
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        content
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>                         
                                        content
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        content
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </td>
                        <td>
                            <%----------------Second Inner Table------------------%>
                            <asp:Table ID="Table2" runat="server">
                                <asp:TableHeaderRow>
                                    <asp:TableHeaderCell>
                            Header
                                    </asp:TableHeaderCell>
                                    <asp:TableHeaderCell>
                            Header
                                    </asp:TableHeaderCell>
                                </asp:TableHeaderRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                            <%---Add your conents as properties----%>
                                     <%= this.ContentString %>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>                         
                                        content
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        content
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>                         
                                        content
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        content
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </td>
                    </tr>
                    <%-- Closing the second row of master table --%>
                    <%-- Everything is completed in the repeater's header! --%>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%--continue master table as usual--%> </td>
                    <td></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </Table>
            </FooterTemplate>
        </asp:Repeater>
