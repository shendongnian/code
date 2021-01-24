    <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
    
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
    private int buttonWasClicked = 0; //Kept a variable type of int and with a default value 0
    
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
       buttonWasClicked = 1; //If clicked, then 1
       Session["value"] = Convert.ToInt32(buttonWasClicked); //Then kept in session
       lblMsg.Text = "Total Price - 10,000";
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
       if (Session["value"] != null) //If session not null, then redirect page
       {
          Response.Redirect("CustomerDetails.aspx");
          Session["value"] = null; //Clears the session
       }
       else
       {
          lblMsg.Text = "Click the calculate button first";
       }
    }
    
