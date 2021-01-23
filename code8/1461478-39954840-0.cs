       <asp:Button CommandName="del" ID="btnDisable" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                            CssClass="btn btn-danger btn-xs disable" />
    
     if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        // HIGHTLIGHT ACTIVE/INACTIVE USERS
                        Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                        Button del = (Button)e.Row.FindControl("btnDisable");
                        if (lblStatus.Text == "False")
                        {
                            lblStatus.CssClass = "label label-success disabled";
                            lblStatus.Text = "Active";
                            //lblStatus.ToolTip = "User is active.";
                            //del.CssClass = "btn btn-mini btn-success ";
                            del.Text = "Disable";
                            //del.ToolTip = "Click here to Inactivate user.";
                        }
                        else
                        {
                            // e.Row.ForeColor = System.Drawing.Color.Red;
                            lblStatus.CssClass = "label label-danger disabled";
                            lblStatus.ToolTip = "User is inactive.";
                            lblStatus.Text = "Inactive";
                            //del.CssClass = "btn btn-mini btn-success ";
                            del.Text = "Enable";
                            //del.ToolTip = "Click here to Activate user.";
                        }
