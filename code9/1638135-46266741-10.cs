    <asp:Button ID="Button1" runat="server" Enabled="false" />
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
       Button1.Enabled = True;
       if(Session["TotalPrice"] != null)
       {
           lblMsg.Text = "Please click here to see total calculation";
       }
    }
    protected void Button1_Confirm(object sender, EventArgs e)
    {
       if(Session["SalesPrice"] != null)
       {
           Response.Redirect("Confirm.aspx");
       }
    }
