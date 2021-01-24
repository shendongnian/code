    <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
    <asp:Label runat="server" ID="MessageLabel" />
    
    protected void Page_Init(object sender, EventArgs e)
    {
        var button = new Button {ID = "Button1"};
        button.Click += Button_Click;
        PlaceHolder1.Controls.Add(button);
    }
    
    private void Button_Click(object sender, EventArgs e)
    {
        MessageLabel.Text = "Button is clicked!";
    }
