    There is complete solution for data row i.e. lable of grid view but not in the databound to datasource. plese try this best solution.so we have an example that is
    
    In aspx page: 
        
    <asp:GridView ID="GridViewBalance" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                DataKeyNames="card_no"  GridLines="None" CssClass="table table-striped"
                                OnPageIndexChanging="GridViewBalance_PageIndexChanging" PageSize="50" AllowPaging="True"
                                 CellSpacing="4">                           
                                <Columns>
                                    <asp:BoundField DataField="card_no" HeaderText="Card No" />
                                    <asp:BoundField DataField="acc_no" HeaderText="Account No" />
                                    <asp:BoundField DataField="cname" HeaderText="Name" />                         
                                    <asp:BoundField DataField="mobileno" HeaderText="Mobile No" />
                                    <asp:BoundField DataField="balance" HeaderText="Balance" />
                                    <asp:BoundField DataField="created_date" HeaderText="Creation date" DataFormatString="{0:d/M/yyyy HH:mm:ss}" />                            
                                  
                                    <asp:TemplateField HeaderText="Active-Status">
                                        <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" ForeColor="White"  Text='<%# GetStatus(Eval("is_active").ToString()) %>' BackColor='<%# GetColor(Eval("is_active").ToString()) %>' ToolTip="Transaction Status"></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                
                            </asp:GridView> 
    
    Code Behind:
    
    This is used for the color of the grid view data rows.
    
       public System.Drawing.Color GetColor(string butColor)
            {
                System.Drawing.Color cr = new System.Drawing.Color();
                if (butColor == "1")
                {
                    cr = System.Drawing.Color.Green;
                }
                else if (butColor == "0")
                {
                    cr = System.Drawing.Color.Red;
                }
                return cr;
            }
    
     This is used for the status:
    
       protected string GetStatus(string butStatus)
            {
                if (butStatus == "1")
                {
                    butStatus = "ACTIVE";
                }
                else if (butStatus == "0")
                {
                    butStatus = "DEACTIVE";
                }
                return butStatus;
            }
