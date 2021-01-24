    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="BillOfLadingID" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="300px" DataField="BillOfLadingID" HeaderText="B/L Number" HeaderStyle-CssClass="GridClass" />
            <asp:TemplateField HeaderText="Select" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" OnRowDataBound="GridView2_RowDataBound">
                        <Columns>
                            <asp:BoundField ItemStyle-Width="300px" DataField="ContainerType" HeaderText="Container Type" HeaderStyle-CssClass="GridClass" />
                            <asp:BoundField ItemStyle-Width="300px" DataField="NumberOfContainer" HeaderText="Number Of Container" HeaderStyle-CssClass="GridClass" />
                            <asp:TemplateField HeaderText="Select" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="300px" DataField="InvoiceChargesType" HeaderText="Perticulars" HeaderStyle-CssClass="GridClass" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="PerUnit" HeaderText="Per Unit" HeaderStyle-CssClass="GridClass" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="InvoiceINR" HeaderText="INR" HeaderStyle-CssClass="GridClass" />
                                            <asp:BoundField ItemStyle-Width="300px" DataField="InvoiceUSD" HeaderText="USD" HeaderStyle-CssClass="GridClass" />
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    string BLID = string.Empty;    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BLID = GridView1.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvOrders = e.Row.FindControl("GridView2") as GridView;
                gvOrders.DataSource = GetData(string.Format("select BookingWiseContainerTbl.ContainerType,BookingWiseContainerTbl.NumberOfContainer from BookingWiseContainerTbl,LinerBLTbl where LinerBLTbl.BookingID=BookingWiseContainerTbl.LineBookingID and LinerBLTbl.BillOfLadingID='{0}'", BLID));
                gvOrders.DataBind();
            }
        }
        
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                GridView gvOrders1 = (sender as GridView).FindControl("GridView3") as GridView;
                gvOrders1.DataSource = GetData(string.Format("select LinerInvoiceWiseChargesTbl.InvoiceChargesType,concat(LinerInvoiceWiseChargesTbl.InvoiceCurrency,'-', LinerInvoiceWiseChargesTbl.InvoiceCharges)as PerUnit,LinerInvoiceWiseChargesTbl.InvoiceINR,LinerInvoiceWiseChargesTbl.InvoiceUSD  from LinerBLTbl,LinerInvoiceWiseChargesTbl  where LinerBLTbl.BillOfLadingID=LinerInvoiceWiseChargesTbl.InvoiceBillOfLadingID and LinerBLTbl.BillOfLadingID='" + BLID + "'"));
                gvOrders1.DataBind();
            }
        }
