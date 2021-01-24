            protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                    {
                        if (e.Row.RowType == DataControlRowType.DataRow)
                        {
                            // Get the LinkButton control in the first cell
                            LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
                            // Get the javascript which is assigned to this LinkButton
            
              string _jsSingle = ClientScript.GetPostBackClientHyperlink(_singleClickButton, "");
                            // To prevent the first click from posting back immediately 
                            // (therefore giving the user a chance to double click) pause the 
                            // postback for 300 milliseconds by using setTimeout
                            _jsSingle = _jsSingle.Insert(11, "setTimeout(\"");
                            _jsSingle += "\", 300)";
                            // Add this javascript to the onclick Attribute of the row
                            e.Row.Attributes["onclick"] = _jsSingle;
            
                            // Get the LinkButton control in the second cell
                            LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];
                            // Get the javascript which is assigned to this LinkButton
                            string _jsDouble = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                            // Add this javascript to the ondblclick Attribute of the row
                            e.Row.Attributes["ondblclick"] = _jsDouble;
                        }
                    }
            
            
            
            
            
            
                    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
                    {
                        GridView _gridView = (GridView)sender;
            
                        // Get the selected index and the command name
                        int _selectedIndex = int.Parse(e.CommandArgument.ToString());
                        string _commandName = e.CommandName;
            
                        switch (_commandName)
                        {
                            case ("SingleClick"):
                                _gridView.SelectedIndex = _selectedIndex;
                                this.Message.Text += "Single clicked GridView row at index " + _selectedIndex.ToString() + "<br />";
                                break;
                            case ("DoubleClick"):
                                Response.Write("<script type='text/javascript'>detailedresults=window.open('Patient//PatientDicomViewPage.aspx');</script>");
            
                                // Response.Redirect("ViewPatient.aspx");
                                this.Message.Text += "Double clicked GridView row at index " + _selectedIndex.ToString() + "<br />";
                                break;
                        }
                    }
        
        
        Design of grid
        
         <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
                    OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>                
                        <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false"/>
                        <asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false"/>
                    </Columns>
                    <RowStyle BackColor="#F7F7DE" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />            
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
    <asp:Label id="Message" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>  
