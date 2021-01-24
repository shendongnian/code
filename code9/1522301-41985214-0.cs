    <asp:UpdatePanel ID="UpdatePanelConnect" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblUsername" runat="server" Text="Enter username:"></asp:Label>
            <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
            <asp:Button ID="btnConnect" runat="server" OnClick="btnConnect_Click" Text="Connect" />
            <asp:TextBox
                ID="tbReceivedMessages"
                runat="server"
                Height="250px"
                TextMode="MultiLine"
                Width="250px"
                MaxLength="2000000"
                ReadOnly="True"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:TextBox ID="tbSendMessage" runat="server"></asp:TextBox>
                <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="Send" />
        </ContentTemplate>
    </asp:UpdatePanel>
    
    public void btnSend_Click(object sender, EventArgs e)
    {
        if (tbSendMessage.Text.Length > 0)
        {
            string message = tbSendMessage.Text;
            // This code won't work.
            /*byte[] outStream = Encoding.ASCII.GetBytes(message + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            tbSendMessage.Text = string.Empty;*/
        }
    }
